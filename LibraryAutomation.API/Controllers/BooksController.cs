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
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepo;
        private readonly IMapper _mapper;
        public BooksController(IGenericRepository<Book> bookRepo, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepo = bookRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var bookList = await _bookRepo.GetContext().Include(x=>x.Author).ToListAsync();
            return Ok(bookList);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookDto bookDto)
        {
            var addBook = _mapper.Map<Book>(bookDto);
            await _bookRepo.AddAsync(addBook);
            return Created("", addBook);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(BookUpdateDto bookUpdateDto)
        {
            var book = await _bookRepo.GetByIdAsync(bookUpdateDto.Id);
            if (book== null) return NotFound("User not found");
            var updateBook = _mapper.Map<Book>(bookUpdateDto);
            _bookRepo.Update(updateBook);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return NotFound("User not found!");
            _bookRepo.Remove(book);
            return Ok();
        }
    }
}

