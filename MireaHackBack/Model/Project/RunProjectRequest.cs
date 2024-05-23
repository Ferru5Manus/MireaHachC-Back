using MireaHackBack.Model;
using MireaHackBack.Model.Project;

namespace MireaHackBack.Model.Project;

public class RunProjectRequest
{
    public string code = null!;
    public LanguageType language;
}
