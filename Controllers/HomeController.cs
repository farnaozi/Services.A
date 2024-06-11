using AutoMapper;
using Services.A.Core.Dtos;
using Services.A.Core.Interfaces;
using Services.A.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IServiceRepo _repo;
        private readonly IMapper _mapper;

        public HomeController(IServiceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage()
        {
            return Ok(await _repo.SendMessage());
        }
    }
}

