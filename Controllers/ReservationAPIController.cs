using AutoMapper;
using Booking_ReservationAPI.Data;
using Booking_ReservationAPI.Models;
using Booking_ReservationAPI.Models.Dto;
using Booking_ReservationAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Booking_ReservationAPI.Controllers
{

    [ApiController]
    [Route("api/ReservationAPI")]

    public class ReservationAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IReservationRepository _dbReservation;
        private readonly IMapper _mapper;

        public ReservationAPIController(IReservationRepository dbReservation, IMapper mapper)
        {
            _dbReservation = dbReservation;
            _mapper = mapper;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetReservations()
        {
            try
            {
                IEnumerable<Reservation> ReservationList = await _dbReservation.GetAllAsync();
                _response.Result = _mapper.Map<List<ReservationDTO>>(ReservationList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }



        [HttpGet("{id:int}", Name = "GetReservation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetReservation(int id)
        {
            try
            {
                if (id == 0)

                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response); 
                }

                var Reservation = await _dbReservation.GetAsync(u => u.Id == id);
                if (Reservation == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;

                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<ReservationDTO>(Reservation);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CreateReservation([FromBody] ReservationCreateDTO createDTO)
        {
            try
            {
                if (await _dbReservation.GetAsync(u => u.CustomerName.ToLower() == createDTO.CustomerName.ToLower()) != null)

                {
                    ModelState.AddModelError("CustomError", "Reservation Already Exist!");

                    return BadRequest(ModelState);
                }



                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }


                Reservation reservation = _mapper.Map<Reservation>(createDTO);

                await _dbReservation.CreateAsync(reservation);
                _response.Result = _mapper.Map<ReservationDTO>(reservation);
                _response.StatusCode = HttpStatusCode.Created;
                //return Ok(_response);
                return CreatedAtRoute("GetReservation", new { id = reservation.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;

        }


        [HttpDelete("{id:int}", Name = "DeleteReservation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> DeleteReservation(int id)
        {
            try
            {
                if (id == 0)
                { return BadRequest(); }

                var reservation = await _dbReservation.GetAsync(u => u.Id == id);
                if (reservation == null)
                { return NotFound(); }

                await _dbReservation.RemoveAsync(reservation);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }



        [HttpPut("{id:int}", Name = "UpdateReservation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateReservation(int id, [FromBody] ReservationUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }

                Reservation model = _mapper.Map<Reservation>(updateDTO);

                await _dbReservation.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }


        [HttpPatch("{id:int}", Name = "UpdatePartialReservation")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialReservation(int id, JsonPatchDocument<ReservationUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }
            var reservation = await _dbReservation.GetAsync(u => u.Id == id, tracked: false);
            ReservationUpdateDTO reservationDTO = _mapper.Map<ReservationUpdateDTO>(reservation);


            if (reservation == null)
            {
                return BadRequest();
            }
            patchDTO.ApplyTo(reservationDTO, ModelState);
            Reservation model = _mapper.Map<Reservation>(reservationDTO);
            await _dbReservation.UpdateAsync(model);
            if (!ModelState.IsValid)
            { return BadRequest(); }
            return NoContent();

        }


    }
}
