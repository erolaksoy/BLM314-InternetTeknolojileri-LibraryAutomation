using AutoMapper;
using LibraryAutomation.API.DTOs;
using LibraryAutomation.API.Interfaces;
using LibraryAutomation.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
