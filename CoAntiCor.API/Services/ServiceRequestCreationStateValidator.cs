using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain.Organization;
using CoAntiCor.Core.Domain.ServiceRequest;
using CoAntiCor.Core.DTO.Incident;
using FluentValidation;
namespace CoAntiCor.API.Services
{
    /// <summary>
    /// stateful, resilient flow. Autosave per step(immediate persistence). Load existing draft and resume.
    /// FluentValidation integration.Simple CSS‑based animated transitions
    /// </summary>
    public class ServiceRequestCreationStateValidator : AbstractValidator<WizardDraftState>
    {
        public ServiceRequestCreationStateValidator()
        {
            RuleSet("Step1", () =>
            {

                RuleFor(x => x.SearchQuery)
                    .NotEmpty()
                    .WithMessage("Search Query is required.")
                    .WithState(_ => "stp1-search-something");

            });

            RuleSet("Step2", () =>
            {
                RuleFor(x => x.Title)
                  .NotEmpty()
                  .WithMessage("Title is required.")
                  .WithState(_ => "stp2-inc-title");

                RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("Description is required.")
               .WithState(_ => "stp2-inc-desc");
                //   // Example: Only validate NaturalPerson fields if the applicant is a physc person
                //   When(x => x.MyEntrepriseTypeGroup == (string)EntrepriseTypeGroup.ETS.ToString(), () =>
                //   {
                //       //requerant = Applicant

                //       RuleFor(x => x.NaturalPersonRequerant!.FirstName).NotEmpty()
                //.WithMessage("Applicant First name is required.")
                //.WithState(_ => "step2-requerant-fname-id");

                //   RuleFor(x => x.NaturalPersonRequerant!.LastName).NotEmpty()
                //    .WithMessage("Applicant Last name is required.")
                //    .WithState(_ => "step2-requerant-lname-id");

                //   RuleFor(x => x.NaturalPersonRequerant!.GenderId)
                //     .NotEmpty()
                //     .WithMessage("Applicant Gender must be selected.")
                //     .WithState(_ => "step2-requerant-gender-id");

                //   RuleFor(x => x.NaturalPersonRequerant!.BirthDate).NotEmpty()
                //    .WithMessage("Applicant Birth date is required.")
                //    .WithState(_ => "step2-requerant-birthdate-id");

                //   RuleFor(x => x.NaturalPersonRequerant!.BirthLocation).NotEmpty()
                //    .WithMessage("Applicant Birth location is required.")
                //    .WithState(_ => "step2-requerant-birthplace-id");

                //   //RuleFor(x => x.NaturalPersonRequerant!.CurrentAddress!.CountryCode).NotEmpty()
                //   //.WithMessage("Applicant Birth country must be selected")
                //   //.WithState(_ => "step2-requerant-birthcountry-id");

                //   RuleFor(x => x.NaturalPersonRequerant!.NationalityCountry).NotEmpty()
                //    .WithMessage("Applicant Nationality country must be selected.")
                //    .WithState(_ => "step2-requerant-nationality-id");

                //   RuleFor(x => x.NaturalPersonRequerant!.PhonePersonal).NotEmpty()
                //    .WithMessage("DRC Mobile phone is required to receive notification.")
                //    .WithState(_ => "step2-requerant-telmobilerdc-id");

                //   RuleFor(x => x.NaturalPersonRequerant!.EmailAddress).NotEmpty()
                //    .WithMessage("Email address is required to receive notification and documents.")
                //    .WithState(_ => "step2-requerant-email-id");



                //   // personne physique assujettie
                //   RuleFor(x => x.NaturalPerson!.FirstName).NotEmpty()
                //  .WithMessage("First name is required.")
                //  .WithState(_ => "step2-personinfo-fname-id");

                //   RuleFor(x => x.NaturalPerson!.LastName).NotEmpty()
                //    .WithMessage("Last name is required.")
                //    .WithState(_ => "step2-personinfo-lname-id");

                //   RuleFor(x => x.NaturalPerson!.GenderId)
                //     .NotEmpty()
                //     .WithMessage("Gender must be selected.")
                //     .WithState(_ => "step2-personinfo-gender-id");

                //   RuleFor(x => x.NaturalPerson!.BirthDate).NotEmpty()
                //    .WithMessage("Birth date is required.")
                //    .WithState(_ => "step2-personinfo-birthdate-id");

                //   RuleFor(x => x.NaturalPerson!.BirthLocation).NotEmpty()
                //    .WithMessage("Birth location is required.")
                //    .WithState(_ => "step2-personinfo-birthplace-id");

                //   //RuleFor(x => x.NaturalPerson!.CurrentAddress!.CountryCode).NotEmpty()
                //   // .WithMessage("Birth country must be selected")
                //   // .WithState(_ => "step2-personinfo-birthcountry-id");

                //   RuleFor(x => x.NaturalPerson!.NationalityCountry).NotEmpty()
                //    .WithMessage("Nationality country must be selected.")
                //    .WithState(_ => "step2-personinfo-nationality-id");

                //   RuleFor(x => x.NaturalPerson!.PhonePersonal).NotEmpty()
                //    .WithMessage("DRC Mobile phone is required to receive notification.")
                //    .WithState(_ => "step2-personinfo-telmobilerdc-id");

                //   RuleFor(x => x.NaturalPerson!.EmailAddress).NotEmpty()
                //    .WithMessage("Email address is required to receive notification and documents.")
                //    .WithState(_ => "step2-personinfo-email-id");

                //   RuleFor(x => x.NaturalPerson!.MaritalStatus).NotEmpty()
                //    .WithMessage("Marital Status must be selected.")
                //    .WithState(_ => "step2-personinfo-maritalstatus-id");

                //   //RuleFor(x => x.NaturalPersonSpouses[0]!.MatrimonialStateId).NotEmpty()
                //   // .WithMessage("Matrimonial state must be selected.")
                //   // .WithState(_ => "step2-personinfo-matrimonialst-id");

                //   RuleFor(x => x.NaturalPerson!.IsCasierJudiciaireProduit).NotEmpty()
                //    .WithMessage("Is Casier Judiciaire Produit is required.")
                //    .WithState(_ => "step2-personinfo-casierjudiciaire-id");
                //   // Attachments
                //   RuleFor(x => x.NaturalPerson!.IdentityFiles.Count)
                //       .GreaterThan(0)
                //       .WithMessage("At least one identity document is required.")
                //        .WithState(_ => "step2-personinfo-IdentityDoc-id");
                //   RuleFor(x => x.NaturalPerson!.IdentityFiles.Count)
                //       .LessThanOrEqualTo(5)
                //       .WithMessage("You can upload a maximum of 5 identity documents.")
                //       .WithState(_ => "step2-personinfo-IdentityDoc-id");




                //});

                //Personne morale
                //When(x => x.MyEntrepriseTypeGroup != (string)EntrepriseTypeGroup.ETS.ToString(), () =>
                //{
                //    //requerant = Applicant

                //    RuleFor(x => x.NaturalPersonRequerant!.FirstName).NotEmpty()
                //     .WithMessage("Applicant First name is required.")
                //     .WithState(_ => "step2-requerant-fname-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.LastName).NotEmpty()
                //     .WithMessage("Applicant Last name is required.")
                //     .WithState(_ => "step2-requerant-lname-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.GenderId)
                //      .NotEmpty()
                //      .WithMessage("Applicant Gender must be selected.")
                //      .WithState(_ => "step2-requerant-gender-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.BirthDate).NotEmpty()
                //     .WithMessage("Applicant Birth date is required.")
                //     .WithState(_ => "step2-requerant-birthdate-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.BirthLocation).NotEmpty()
                //     .WithMessage("Applicant Birth location is required.")
                //     .WithState(_ => "step2-requerant-birthplace-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.CurrentAddress!.CountryCode).NotEmpty()
                //     .WithMessage("Applicant Birth country must be selected")
                //     .WithState(_ => "step2-requerant-birthcountry-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.NationalityCountry).NotEmpty()
                //     .WithMessage("Applicant Nationality country must be selected.")
                //     .WithState(_ => "step2-requerant-nationality-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.PhonePersonal).NotEmpty()
                //     .WithMessage("DRC Mobile phone is required to receive notification.")
                //     .WithState(_ => "step2-requerant-telmobilerdc-id");

                //    RuleFor(x => x.NaturalPersonRequerant!.EmailAddress).NotEmpty()
                //     .WithMessage("Email address is required to receive notification and documents.")
                //     .WithState(_ => "step2-requerant-email-id");


                //    RuleFor(x => x.RequerantAddressHistories).NotEmpty()
                //      .WithMessage("Requerant address is required.")
                //      .WithState(_ => "step2-requerant-requerantaddress-id");


                //});


            });


            RuleSet("Step3", () =>
            {
               // RuleFor(x => x.CompanyType).NotEmpty();
              //  RuleFor(x => x.ActivitySector).NotEmpty();
               // RuleFor(x => x.IndustryType).NotEmpty();
                //RuleFor(x => x.PhysicPerson).NotEmpty();
                //RuleFor(x => x.PhysicPerson!.OrganizationAddress).NotEmpty();
                // RuleFor(x => x.PhysicPerson!.Email).NotEmpty().EmailAddress();

                // Business Activity Info in Step 2

                //RuleFor(x => x.PhysicPerson!.ActivitySector).NotEmpty()
                //  .WithMessage("Activity sector must be selected.")
                //  .WithState(_ => "step2-personinfo-activitysector-id");

                //RuleFor(x => x.NaturalPerson!.ActivityType).NotEmpty()
                //   .WithMessage("Activity type must be selected.")
                //   .WithState(_ => "step2-personinfo-activitytype-id");
            });

            RuleSet("Step5", () =>
            {
                //RuleFor(x => x.Card!.CardNumber).NotEmpty();
                //RuleFor(x => x.Card!.CardholderName).NotEmpty();
                //RuleFor(x => x.Card!.ExpiryMonth).NotEmpty();
                //RuleFor(x => x.Card!.ExpiryYear).NotEmpty();
            });

            RuleSet("Step6", () =>
            {
                //RuleFor(x => x.Card!.CardNumber).NotEmpty();
                //RuleFor(x => x.Card!.CardholderName).NotEmpty();
                //RuleFor(x => x.Card!.ExpiryMonth).NotEmpty();
                //RuleFor(x => x.Card!.ExpiryYear).NotEmpty();
            });
        }
    }

}
