using System;
using System.Collections.Generic;

namespace SurveyTask.Models;

public partial class SurveyProgress
{
    public int Id { get; set; }

    public string? SurveyName { get; set; }

    public int? StatusId { get; set; }
}
