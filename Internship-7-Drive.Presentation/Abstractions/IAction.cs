﻿
namespace Internship_7_Drive.Presentation.Abstractions
{
    public interface IAction
    {
        int MenuIndex { get; set; }
        string Name { get; set; }
        void Open();
    }
}
