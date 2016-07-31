using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Forms.Core.PostSubmissionActor;

namespace CustomActorDemo.FormProperties
{
    [Serializable]
    public class KeyValuePairModel : IPostSubmissionActorModel, ICloneable
    {
        [Display(Order = 100)]
        public virtual string Key { get; set; }

        [Display(Order = 200)]
        public virtual string Value { get; set; }

        public object Clone()
        {
            return new KeyValuePairModel
            {
                Key = Key,
                Value = Value
            };
        }
    }
}