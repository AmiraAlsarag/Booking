using AutoMapper;
using Booking_web.Models;
using Booking_web.Models.Dto;
using Booking_web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Booking_web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;
        public ReservationController(IReservationService reservationService,IMapper mapper)
        { _reservationService = reservationService; 
            _mapper = mapper;
            
        }

        public async Task<IActionResult> IndexReservation()
        {
            List<ReservationDTO> list = new();

            var response = await _reservationService.GetAllAsync<APIResponse>();
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ReservationDTO>>(Convert.ToString(response.Result));
            }

            return View(list);
        }
		public async Task<IActionResult> CreateReservation()
		{

			return View();
		}


        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateReservation(ReservationCreateDTO model)
		{
			
			if (ModelState.IsValid)
			{

				var response = await _reservationService.CreateAsync<APIResponse>(model);
				if (response != null && response.IsSuccess)
				{
                    return RedirectToAction(nameof(IndexReservation));
				}

			}

			return View(model);
		}
	}
}
