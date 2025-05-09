using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRBusinessLayer.Abstract;
using SignalRDtoLayer.ContactDto;
using SignalREntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactGet()
        {
            var value = _contactService.TGetListAll();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult ContactCreate(CreateContactDto createContactDto)
        {
            var contact=_mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(contact);
            return Ok("İletişim Adresi Eklendi");
        }

        [HttpDelete]
        public IActionResult ContactDelete(int id)
        {
            var value=_contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok("İletişim Bilgisi Silindi");
        }

        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
        {
            var values=_mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(values);
            return Ok("İletişim Adresi Güncellendi");
        }
    }
}
