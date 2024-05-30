using System;
using FluentValidation;

namespace DDDSample.Application.Customers.GetAll
{
	public class GetAllCustomersQueryValidator : AbstractValidator<GetAllCustomersQuery>
	{
		public GetAllCustomersQueryValidator()
		{

		}
	}
}

