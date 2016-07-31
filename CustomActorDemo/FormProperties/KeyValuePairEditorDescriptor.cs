using System.Collections.Generic;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace CustomActorDemo.FormProperties
{
    [EditorDescriptorRegistration(
        TargetType = typeof(IEnumerable<KeyValuePairModel>),
        UIHint = nameof(KeyValuePairProperty))]
    public class KeyValuePairEditorDescriptor : CollectionEditorDescriptor<KeyValuePairModel>
    {
        public KeyValuePairEditorDescriptor()
        {
            ClientEditingClass = "epi-forms/contentediting/editors/CollectionEditor";
        }
    }
}