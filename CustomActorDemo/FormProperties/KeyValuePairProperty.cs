using EPiServer.Forms.EditView;
using EPiServer.Framework.DataAnnotations;
using EPiServer.PlugIn;

namespace CustomActorDemo.FormProperties
{
    [EditorHint(nameof(KeyValuePairProperty))]
    [PropertyDefinitionTypePlugIn]
    public class KeyValuePairProperty : PropertyGenericList<KeyValuePairModel>
    {
    }
}