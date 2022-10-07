﻿using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;

        public AccountController(DataContext context, ITokenService tokenService)
        {
            _context=context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        //ActionResult kann z.B. ein BadRequest sein
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512(); // using ruft dispose() function der Klasse auf.
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt= hmac.Key
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(user => user.UserName == username.ToLower());
        }

        [HttpPost("login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _context.Users
                .Include(p=>p.Photos)
                .SingleOrDefaultAsync(user => user.UserName == loginDto.Username);
            if (user == null) { return Unauthorized("Invalid username"); }
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for(var i=0; i<computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) { return Unauthorized("Invalid password"); }
            }
            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url
            };
        }
    }
}
