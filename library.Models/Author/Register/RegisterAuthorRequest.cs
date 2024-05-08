﻿namespace library.Models;

public class RegisterAuthorRequest
{
    public required string FullName { get; set; }    
    public required string Email {get; set;}
    public required string Password {get; set;}
}
