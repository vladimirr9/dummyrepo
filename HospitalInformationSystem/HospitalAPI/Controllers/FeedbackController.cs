﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Dto;
using HospitalAPI.Mapper;
using System.Collections.ObjectModel;
using HospitalClassLib.Schedule.Model;
using HospitalClassLib.Schedule.Repository.FeedbackRepository;
using HospitalClassLib.Schedule.Service;
using HospitalAPI.Validators;
using FluentValidation.Results;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService feedbackService;
        private readonly FeedbackRepository feedbackRepository;
        private readonly FeedbackValidator validator;

        public FeedbackController(FeedbackService feedbackService, FeedbackRepository feedbackRepository)
        {
            this.feedbackService = feedbackService;
            this.feedbackRepository = feedbackRepository;
            this.validator = new FeedbackValidator();
        }

        [HttpGet]
        [Route("approved")]
        public IActionResult GetApprovedFeedbacks() 
        {
            return Ok(feedbackRepository.GetApproved());
        }

        [HttpGet]
        public List<Feedback> GetFeedbacks()
        {
            return feedbackService.GetAll();
        }

        [HttpGet("{id?}")]
        public IActionResult GetFeedback(int id)
        {
            return Ok(feedbackService.Get(id));
        }

        [HttpPost]
        public IActionResult AddFeedback(FeedbackDto feedbackDto)
        {
            if (validator.Validate(feedbackDto).IsValid)
                return Ok(feedbackService.Create(FeedbackMapper.FeedbackDtoToFeedback(feedbackDto)));
            else
                return BadRequest();
        }

        [HttpDelete("{id?}")]
        public IActionResult DeleteFeedback(int id)
        {
            return Ok(feedbackService.Delete(id));
        }

        [HttpPut("{id}")]
        public void ApproveFeedback(int id)
        {
            feedbackService.ApproveFeedback(id);
        }

        [HttpPut("remove/{id}")]
        public void RemoveFeedback(int id)
        {
            feedbackService.RemoveFeedback(id);
        }
    }
}
