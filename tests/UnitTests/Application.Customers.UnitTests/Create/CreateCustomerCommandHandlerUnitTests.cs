﻿using System;
using DDDSample.Domain.Customers;
using DDDSample.Domain.Primitives;
using DDDSample.Application.Customers.Create;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Customers.UnitTests.Create
{
    public class CreateCustomerCommandHandlerUnitTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateCustomerCommandHandler _handler;

        public CreateCustomerCommandHandlerUnitTests()
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _handler = new CreateCustomerCommandHandler(_mockUnitOfWork.Object, _mockCustomerRepository.Object);
        }

        [Fact]
        public async Task HandleCreateCustomer_WhenPhoneNumberHasBadFormat_ShouldReturnValidationError()
        {
            //Arrange
            // Se configura los parametros de entrada de nuestra prueba unitaria.
            CreateCustomerCommand command = new CreateCustomerCommand("Fernando", "Ventura", "fe939@mc.com", "33049439443",
            "", "", "", "", "", "");
            //Act
            // Se ejecuta el metodo a probar de nuestra prueba unitaria
            var result = await _handler.Handle(command, default);
            //Assert
            // Se verifica los datos de retorno de nuestro metodo probado en la prueba unitaria
            result.IsError.Should().BeTrue();
            result.FirstError.Type.Should().Be(ErrorType.Validation);
            result.FirstError.Code.Should().Be(DDDSample.Domain.DomainErrors.Errors.Customer.PhoneNumberWithBadFormat.Code);
            result.FirstError.Description.Should().Be(DDDSample.Domain.DomainErrors.Errors.Customer.PhoneNumberWithBadFormat.Description);
        }
    }
}

