using AutoMapper;
using LibraryAutomation.API.Context;
using LibraryAutomation.API.DTOs;
using LibraryAutomation.API.Interfaces;
using LibraryAutomation.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public UsersController(IGenericRepository<User> userRepo, IMapper mapper, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var userList = await _userRepo.GetAllAsync();
            
            return Ok(_context.Users.Include(x=>x.BorrowBooks).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto userAddDto)
        {
            var addUser = _mapper.Map<User>(userAddDto);
            await _userRepo.AddAsync(addUser);
            return Created("",addUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = await _userRepo.GetByIdAsync(userUpdateDto.Id);
            if (user == null) return NotFound("User not found");
            var updateUser = _mapper.Map<User>(userUpdateDto);
            _userRepo.Update(updateUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound("User not found!");
             _userRepo.Remove(user);
            return Ok();
        }
    }
}
