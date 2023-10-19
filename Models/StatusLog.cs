using System;
using System.Collections.Generic;

namespace SurveyTask.Models;

public partial class StatusLog
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? Time { get; set; }

    public int? StatusId { get; set; }
}
