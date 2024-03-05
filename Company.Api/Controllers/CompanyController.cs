using AutoMapper;
using CompanyApi.Api.ViewModel;
using CompanyApi.Domain.Entities;
using CompanyApi.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICompanyService _companyService;
        public CompanyController(IMapper mapper, ICompanyService companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyViewModel>>> Buscar()
        {
            var result = await _companyService.Buscar();

            var companies = _mapper.Map<List<Company>>(result);

            return Ok(companies);
        }
        
        [HttpGet]
        [Route("ObterPorId")]
        public async Task<ActionResult<CompanyViewModel>> ObterPorId(int id)
        {
            var result = await _companyService.ObterPorId(id);

            if(result == null)
            {
                return NotFound();
            }

            var company = _mapper.Map<Company>(result);

            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Adicionar(CompanyViewModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var comp = _mapper.Map<Company>(company);

            var result = await _companyService.Adicionar(comp);

            if(!result)
            {
                return BadRequest();
            }

            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Atualizar(int id, [FromBody] CompanyViewModel company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var companySaved = await _companyService.ObterPorId(id);

            if(companySaved == null)
            {
                return BadRequest();

            }
            var comp = _mapper.Map<Company>(company);

            var result = await _companyService.Atualizar(comp);

            if(!result)
            {
                return BadRequest();
            }

            return Ok(company);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> ExclusaoLogica(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();

            }

            var company = await _companyService.ObterPorId(id);

            if(company == null)
            {
                return BadRequest();

            }
            var comp = _mapper.Map<Company>(company);

            var result = await _companyService.ExclusaoLogica(comp);

            if(!result)
            {
                return BadRequest();
            }

            return Ok(company);
        }
    }
}
