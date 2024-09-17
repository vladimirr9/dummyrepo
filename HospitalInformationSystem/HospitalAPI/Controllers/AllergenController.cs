﻿using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Service;
using HospitalClassLib.SharedModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AllergenController : ControllerBase
    {
        private readonly AllergenService allergenService;
        private readonly AllergenRepository allergenRepository;
        public AllergenController(AllergenService allergenService, AllergenRepository allergenRepository)
        {
            this.allergenService = allergenService;
            this.allergenRepository = allergenRepository;
        }

        [HttpGet]
        public List<Allergen> GetAllergens()
        {
            return allergenService.GetAll();
        }
    }
}
