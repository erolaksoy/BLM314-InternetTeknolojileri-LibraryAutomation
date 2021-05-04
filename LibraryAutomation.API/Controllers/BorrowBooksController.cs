using AutoMapper;
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
    public class BorrowBooksController : ControllerBase
    {
        private readonly IGenericRepository<BorrowBook> _repo;
        private readonly IMapper _mapper;
        public BorrowBooksController(IGenericRepository<BorrowBook> repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> AddBorrowBook(BorrowBookAddDto borrowBookAddDto)
        {
            var entity = _mapper.Map<BorrowBook>(borrowBookAddDto);
            await _repo.AddAsync(entity);
            return Created("",entity);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var bookList = await _repo.GetContext().Include(x => x.User).Include(x=>x.Book).ToListAsync();
            return Ok(bookList);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }
       

        [HttpPut]
        public async Task<IActionResult> UpdateEntity(BorrowBookAddDto borrowBookDto)
        {
            var entity = await _repo.GetByIdAsync(borrowBookDto.Id);
            if (entity == null) return NotFound("Borrow is not found");
            var updateBook = _mapper.Map<BorrowBook>(borrowBookDto);
           _repo.Update(updateBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await _repo.GetByIdAsync(id);
            if (entity == null) return NotFound("Entity not found!");
            _repo.Remove(entity);
            return Ok();
        }
    }
}
