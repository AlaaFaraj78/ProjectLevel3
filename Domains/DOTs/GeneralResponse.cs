
using Pioneersacademy.Domains.Enums;
using Pioneersacademy.Domains.Entities;
using System.Collections.Generic;

namespace Pioneersacademy.Domains.DTOs;

public class GeneralResponse
{
    public string Message { get; set; }
    public ResponseTypeEnum ResponseType { get; set; }

    public User UserInfo { get; set; }
}
