using System;
using ErrorOr;

namespace DDDSample.Domain.DomainErrors
{
	public static partial class Errors
	{
        public static class Customer
        {
			public static Error PhoneNumberWithBadFormat => Error.Validation("Customer.PhoneNumber", "Phone number has not valid format");

            public static Error AddressWithBadFormat => Error.Validation("Customer.Address", "Address is not valid.");
        }
	}
}

