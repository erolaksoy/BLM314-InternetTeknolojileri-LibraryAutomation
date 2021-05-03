using AutoMapper;
using LibraryAutomation.API.Interfaces;
using LibraryAutomation.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAutomation.API.DTOs
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IGenericRepository<Author> _repo;
        private readonly IMapper _mapper;
        public AuthorsController(IGenericRepository<Author> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var AuthorList = await _repo.GetAllAsync();
            return Ok(AuthorList);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorDto authorDto)
        {
            var addEntity = _mapper.Map<Author>(authorDto);
            await _repo.AddAsync(addEntity);
            return Created("", addEntity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(AuthorUpdateDto authorUpdateDto)
        {
            var author = await _repo.GetByIdAsync(authorUpdateDto.Id);
            if (author == null) return NotFound("User not found");
            var updateAuthor = _mapper.Map<Author>(authorUpdateDto);
            _repo.Update(updateAuthor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _repo.GetByIdAsync(id);
            if (author == null) return NotFound("User not found!");
            _repo.Remove(author);
            return Ok();
        }
    }
}
