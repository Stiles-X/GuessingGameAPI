using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    interface ModelInterface
    {
        int Max { get; set; }
        int Min { get; set; }
        int Correct { get; set; }
        int AllowedGuesses { get; set; }
        int UsedGuesses { get; set; }
    }
}
