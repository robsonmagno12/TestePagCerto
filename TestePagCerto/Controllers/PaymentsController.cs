using Arch.EntityFrameworkCore;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TestePagCerto.Infrastructure.Dtos.Payment;
using TestePagCerto.Models;
using FluentResults;


namespace TestePagCerto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public PaymentsController(DbContext dbContext,  IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult AddPayment(CreatePaymentDto paymentDto)
        {
            Payment payment = _mapper.Map<Payment>(paymentDto);
            _context.Payment.Add(payment);
            _context.SaveChanges();
            return _mapper.Map<ReadPaymentDto>(payment);
        }

        [HttpGet]
        public List<ReadPaymentDto> RecPayment(string namePayment)
        {
            List<Payment> payment = _context.payments.ToList();
            if (payment == null)
            {
                return null;
            }
            if (!String.IsNullOrEmpty(namePayment))
            {

                IEnumerable<Payment> query = from Payment in payment
                                             where payment
                                             select payment;
                payment = query.ToList();
            }
            //_mapper.Map quero mapear para a lista de cinema
            return _mapper.Map<List<ReadPaymentDto>>(payment);

        }

        [HttpGet("{id}")]
        public ReadPaymentDto RecPaymenhtsId(int id)
        {
            Payment payment = _context.payments.FirstOrDefault(payment => payment.Id == id);
            if (payment != null)
            {
                ReadPaymentDto paymentDto = _mapper.Map<ReadPaymentDto>(payment);
                return paymentDto;
            }
            return null;
        }

        [HttpPut("{id}")]
        public Result UpdatePayment(int id, UpdatePaymentDto paymentDto)
        {
            Payment payment = _context.payments.FirstOrDefault(payment => payment.Id == id);
            if (payment == null)
            {
                return Result.Fail("not found");
            }
            _mapper.Map(paymentDto, payment);
            _context.SaveChanges();
            return Result.Ok();
        }

        [HttpDelete]
        public Result DeletePaymert(int id)
        {
            Payment payment = _context.payments.FirstOrDefault(payment => payment.Id == id);
            if (payment == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _context.Remove(payment);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
