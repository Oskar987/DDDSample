﻿namespace DDDSample.Application.Users.Common
{    
    public record UserResponse(
        string DisplayName,
        string Token,
        string UserName);
}

