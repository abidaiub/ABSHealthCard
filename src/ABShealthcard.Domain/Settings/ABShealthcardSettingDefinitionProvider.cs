using Volo.Abp.Settings;

namespace ABShealthcard.Settings;

public class ABShealthcardSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(ABShealthcardSettings.MySetting1));
    }
}
