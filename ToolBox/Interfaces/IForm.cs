namespace ToolBox.Interfaces;

public interface IForm
{
    bool CloseForm { get; set; }

    string FormTitle { get; set; }

    ModoJanela FormMode { get; set; }

    Point GetCenterPoint();
}