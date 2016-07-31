using System;
using System.Collections.Generic;
using System.Linq;
using CustomActorDemo.Crm;
using CustomActorDemo.FormHelpers;
using CustomActorDemo.FormProperties;
using EPiServer.Forms.Core.Data;
using EPiServer.Forms.Core.PostSubmissionActor;
using EPiServer.Forms.EditView;
using EPiServer.ServiceLocation;

namespace CustomActorDemo.Actors
{
    public class CustomActor : PostSubmissionActorBase, IUIPropertyCustomCollection
    {
        private readonly Injected<IFormDataRepository> _formDataRepository;

        public override object Run(object input)
        {
            // skip execution if KeyValuePair is empty
            var model = Model as List<KeyValuePairModel>;
            if (model == null || !model.Any())
            {
                return string.Empty;
            }

            // skip execution if "runCustomActor" is not set to "true"
            var pair = model.FirstOrDefault(x => x.Key == "runCustomActor");
            if (pair == null || pair.Value != "true")
            {
                return string.Empty;
            }

            var submittedData = _formDataRepository.Service.TransformSubmissionDataWithFriendlyName(
                SubmissionData.Data, SubmissionFriendlyNameInfos, true).ToList();

            var messageDto = submittedData.ToObject<MessageDto>();

            // TODO: send messageDto to the CRM


            return string.Empty;
        }

        public virtual Type PropertyType => typeof(KeyValuePairProperty);
    }
}