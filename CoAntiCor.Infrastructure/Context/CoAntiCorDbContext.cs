using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Domain.Address;
using CoAntiCor.Core.Domain.CodeTables;
using CoAntiCor.Core.Domain.Email;
using CoAntiCor.Core.Domain.Finance;
using CoAntiCor.Core.Domain.FredTicketCreation;
using CoAntiCor.Core.Domain.Organization;
using CoAntiCor.Core.Domain.Organization.Document;
using CoAntiCor.Core.Domain.Organization.OrganizationDetails;
using CoAntiCor.Core.Domain.Organization.PaymentInfo;
using CoAntiCor.Core.Domain.Organization.PaymentMethods;
using CoAntiCor.Core.Domain.PaymentMethods;
using CoAntiCor.Core.Domain.Person;
using CoAntiCor.Core.Domain.Processing;
using CoAntiCor.Core.Domain;
using CoAntiCor.Core.Model;
using CoAntiCor.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using CoAntiCor.Core.Interfaces;

namespace CoAntiCor.Infrastructure.Context
{
    public class CoAntiCorDbContext : IdentityDbContext<Core.Domain.ApplicationUser>
    {
        private readonly ITenantContext? _tenant;

        public CoAntiCorDbContext(DbContextOptions<CoAntiCorDbContext> options, ITenantContext tenant) : base(options)
        {
            _tenant = tenant;
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();

        public DbSet<IncidentType> IncidentTypes => Set<IncidentType>();
        public DbSet<IncidentCategory> IncidentCategories => Set<IncidentCategory>();
        public DbSet<GovernmentOffice> GovernmentOffices => Set<GovernmentOffice>();

        public DbSet<Complaint> Complaints => Set<Complaint>();
        public DbSet<ComplaintAttachment> ComplaintAttachments => Set<ComplaintAttachment>();
        public DbSet<ProcessingPhase> ProcessingPhases => Set<ProcessingPhase>();
        public DbSet<ComplaintHistory> ComplaintHistories => Set<ComplaintHistory>();
        public DbSet<ComplaintReward> ComplaintRewards => Set<ComplaintReward>();
        public DbSet<AuditLog> AuditLogs => Set<AuditLog>();
        public DbSet<ComplaintDraft> ComplaintDrafts => Set<ComplaintDraft>();
        public DbSet<ComplaintDraftActivity> ComplaintDraftActivities => Set<ComplaintDraftActivity>();
        public DbSet<ComplaintNumberSequence> ComplaintNumberSequences => Set<ComplaintNumberSequence>();


        // Additional person-related entities from CoAntiCor.Core.Domain.Person
        public DbSet<NaturalPerson> NaturalPeople => Set<NaturalPerson>();
        public DbSet<NaturalPersonSpouse> NaturalPersonSpouses => Set<NaturalPersonSpouse>();
        public DbSet<PhysicPerson> PhysicPeople => Set<PhysicPerson>();
        public DbSet<ContactUsEmail> ContactUsEmails => Set<ContactUsEmail>();
        public DbSet<Release> Releases => Set<Release>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Commune> Communes => Set<Commune>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Province> Provinces => Set<Province>();
        public DbSet<Quartier> Quartiers => Set<Quartier>();
        public DbSet<RoadType> RoadTypes => Set<RoadType>();
        public DbSet<Territory> Territories => Set<Territory>();
        public DbSet<ContactTypeCodeTableItem> ContactTypeCodeTableItems => Set<ContactTypeCodeTableItem>();
        public DbSet<CountryCodeTableItem> CountryCodeTableItems => Set<CountryCodeTableItem>();
        public DbSet<EmailCodeTableItem> EmailCodeTableItems => Set<EmailCodeTableItem>();
        public DbSet<FileTypeCodeTableItem> FileTypeCodeTableItems => Set<FileTypeCodeTableItem>();
        public DbSet<FootPrintTypeCodeTableItem> FootPrintTypeCodeTableItems => Set<FootPrintTypeCodeTableItem>();
        public DbSet<MediaTypeCodeTableItem> MediaTypeCodeTableItems => Set<MediaTypeCodeTableItem>();
        public DbSet<OrderTypeCodeTableItem> OrderTypeCodeTableItems => Set<OrderTypeCodeTableItem>();
        public DbSet<ProvinceCodeTableItem> ProvinceCodeTableItems => Set<ProvinceCodeTableItem>();
        public DbSet<ServiceTypeCodeTableItem> ServiceTypeCodeTableItems => Set<ServiceTypeCodeTableItem>();
        public DbSet<Email> Emails => Set<Email>();
        public DbSet<EmailAttachment> EmailAttachments => Set<EmailAttachment>();
        public DbSet<EmailExecution> EmailExecutions => Set<EmailExecution>();
        public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();
        public DbSet<EnterpriseType> EnterpriseTypes => Set<EnterpriseType>();
        public DbSet<OrganizationCategory> OrganizationCategories => Set<OrganizationCategory>();

        public DbSet<OrganizationAddress> OrganizationAddresses => Set<OrganizationAddress>();
        public DbSet<PaymentMethod> PaymentMethods => Set<PaymentMethod>();

        public DbSet<Bank> Banks => Set<Bank>();
        public DbSet<Currency> Currencies => Set<Currency>();

        public DbSet<Civility> Civilities => Set<Civility>();
        public DbSet<Gender> Genders => Set<Gender>();
        public DbSet<MaritalStatus> MaritalStatuses => Set<MaritalStatus>();
        public DbSet<NaturalPersonAddress> NaturalPersonAddresses => Set<NaturalPersonAddress>();
        public DbSet<DecisionControl> DecisionControls => Set<DecisionControl>();
        public DbSet<ReasonRejected> ReasonRejecteds => Set<ReasonRejected>();

        public DbSet<AuthorizedOfficial> AuthorizedOfficials => Set<AuthorizedOfficial>();

        public DbSet<Certificate> Certificates => Set<Certificate>();
        public DbSet<ActionLog> ActionLogs { get; set; }
        public DbSet<FredRequestFile> FredRequestFiles => Set<FredRequestFile>();
        public DbSet<EmailQueueItem> EmailQueue => Set<EmailQueueItem>();

        public DbSet<PaymentLog> PaymentLogs => Set<PaymentLog>();
        //public DbSet<PaymentStatus> PaymentStatuses => Set<PaymentStatus>();
        public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
        public DbSet<BitCoin> BitCoins => Set<BitCoin>();
        public DbSet<CashOnDelivery> CashOnDeliveries => Set<CashOnDelivery>();
        //public DbSet<CreditCardInfo> CreditCardInfos => Set<CreditCardInfo>();
        public DbSet<GiftCardPayInAdvance> GiftCardPayInAdvances => Set<GiftCardPayInAdvance>();
        public DbSet<MobileMoney> MobileMoneys => Set<MobileMoney>();
        public DbSet<PayPal> PayPals => Set<PayPal>();
        public DbSet<UserPaymentMethod> UserPaymentMethods => Set<UserPaymentMethod>();
        public DbSet<RegulatorOfficePermission> RegulatorOfficePermissions { get; set; } = default!;
        public DbSet<RegulatorProvincePermission> RegulatorProvincePermissions { get; set; } = default!;
        public DbSet<IntegrityLog> IntegrityLogs => Set<IntegrityLog>();
        public DbSet<TenantAuditEntry> TenantAuditEntrys => Set<TenantAuditEntry>();
        public DbSet<SignatureAudit> SignatureAudits => Set<SignatureAudit>();
        public DbSet<Core.Domain.Contract> Contracts => Set<Core.Domain.Contract>();
        public DbSet<BrokerOffice> BrokerOffices => Set<BrokerOffice>();


        public DbSet<MenuItem> MenuItems => Set<MenuItem>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /////////////////////////////////////

            // Complaint Number Sequence CONFIGURATION -------------------------------------

            modelBuilder.Entity<ComplaintNumberSequence>().HasData(
            new ComplaintNumberSequence
            {
                Id = 1,
                Year = DateTime.UtcNow.Year,
                LastNumber = 0
            });

            // USER ROLE CONFIGURATION -------------------------------------

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = Guid.Parse("11121111-2312-1111-3333-111117111111"),
                    Name = "Admin"
                },
                new Role
                {
                    Id = Guid.Parse("22212222-3333-2222-3333-222272622222"),
                    Name = "Citizen"
                },
                new Role
                {
                    Id = Guid.Parse("33134333-3223-1111-3333-333345333333"),
                    Name = "InternalStaff"
                },
                new Role
                {
                    Id = Guid.Parse("44544424-4454-2244-3354-444433444444"),
                    Name = "Manager"
                },
                new Role
                {
                    Id = Guid.Parse("55556555-5555-2155-5755-555352255555"),
                    Name = "Executive"
                },
                new Role
                {
                    Id = Guid.Parse("66162666-2266-7377-4466-616661166666"),
                    Name = "Inspector"
                },
                new Role
                {
                    Id = Guid.Parse("77737877-1277-5555-7577-777947777777"),
                    Name = "Prosecutor"
                },
                new Role
                {
                    Id = Guid.Parse("88734177-6277-2555-7567-872147377777"),
                    Name = "SpecialInvestigator"
                }
            );



            // COMPLAINT CONFIGURATION -------------------------------------

            modelBuilder.Entity<Complaint>()
                .HasIndex(c => c.ComplaintNumber)
                .IsUnique();

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.ReporterUser)
                .WithMany(u => u.ComplaintsInitiated)
                .HasForeignKey(c => c.ReporterUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProcessingPhase>()
                .HasOne(p => p.AssignedToUser)
                .WithMany(u => u.AssignedPhases)
                .HasForeignKey(p => p.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Complaint>()
                .HasOne(c => c.AssignedToUser)
                .WithMany()
                .HasForeignKey(c => c.AssignedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ComplaintReward>()
                .HasOne(r => r.Complaint)
                .WithOne(c => c.Reward)
                .HasForeignKey<ComplaintReward>(r => r.ComplaintId);

            /*
             *  Why Restrict is the correct choice
                Incident categories and types are lookup tables.
                They should never be deleted automatically.
                If someone tries to delete a category that still has types, SQL Server will block it — which is exactly what you want.
             */
            modelBuilder.Entity<Complaint>()
                 .HasOne(c => c.IncidentType)
                 .WithMany(it => it.Complaints)
                 .HasForeignKey(c => c.IncidentTypeId)
                 .OnDelete(DeleteBehavior.Restrict);

            // NATURAL P[ERSON CONFIGURATION -------------------------------------
            modelBuilder.Entity<PhysicPerson>()
               .HasOne(c => c.NaturalPerson)
               .WithMany(it => it.PhysicPersons)
               .HasForeignKey(c => c.NaturalPersonId)
               .OnDelete(DeleteBehavior.Restrict);

            // NATURAL PERSON CONFIGURATION -------------------------------------
            modelBuilder.Entity<AuditLog>()
       .HasIndex(a => a.TimestampUtc);

            modelBuilder.Entity<AuditLog>()
                .HasIndex(a => new { a.EntityType, a.EntityId });

            // Additional configuration - IncidentType

            modelBuilder.Entity<IncidentType>()
                .HasOne(it => it.IncidentCategory)
                .WithMany(c => c.IncidentTypes)
                .HasForeignKey(it => it.IncidentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<IncidentType>().HasData(
                // Existing core incident types
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Name = "Bribery",
                    Description = "Offering, giving, receiving, or soliciting something of value to influence an official action.",
                    NameFrench = "Corruption (Pot-de-vin)",
                    DescriptionFrench = "Offrir, donner, recevoir ou solliciter quelque chose de valeur pour influencer une action officielle.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000003") // Corruption and Influence
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Name = "Embezzlement",
                    Description = "Misappropriation or theft of public funds or assets entrusted to an official.",
                    NameFrench = "Détournement de fonds",
                    DescriptionFrench = "Appropriation ou vol de fonds ou biens publics confiés à un agent.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000001") // Financial Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Name = "Fraud",
                    Description = "Deception intended to result in financial or personal gain at the expense of the state.",
                    NameFrench = "Fraude",
                    DescriptionFrench = "Tromperie visant à obtenir un gain financier ou personnel au détriment de l'État.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000001") // Financial Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    Name = "Conflict of Interest",
                    Description = "A situation where an official’s personal interests improperly influence their public duties.",
                    NameFrench = "Conflit d’intérêts",
                    DescriptionFrench = "Situation où les intérêts personnels d’un agent influencent indûment ses fonctions publiques.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000002") // Administrative Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    Name = "Abuse of Power",
                    Description = "Using official authority for personal gain or to harm others.",
                    NameFrench = "Abus de pouvoir",
                    DescriptionFrench = "Utilisation de l’autorité officielle pour un gain personnel ou pour nuire à autrui.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000002") // Administrative Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000006"),
                    Name = "Nepotism",
                    Description = "Favoring relatives or friends for jobs, contracts, or benefits.",
                    NameFrench = "Népotisme",
                    DescriptionFrench = "Favoriser des proches ou amis pour des emplois, contrats ou avantages.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000002") // Administrative Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000007"),
                    Name = "Tax Evasion",
                    Description = "Illegal avoidance of paying taxes owed to the government.",
                    NameFrench = "Évasion fiscale",
                    DescriptionFrench = "Éviter illégalement de payer les impôts dus à l’État.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000001") // Financial Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000008"),
                    Name = "Public Procurement Fraud",
                    Description = "Manipulation of bidding, contracting, or procurement processes.",
                    NameFrench = "Fraude dans les marchés publics",
                    DescriptionFrench = "Manipulation des processus d’appel d’offres, de contrats ou d’achats publics.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000003") // Corruption and Influence
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000009"),
                    Name = "Misuse of Public Resources",
                    Description = "Using government vehicles, funds, or assets for personal purposes.",
                    NameFrench = "Utilisation abusive des ressources publiques",
                    DescriptionFrench = "Utilisation des véhicules, fonds ou biens de l’État à des fins personnelles.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000001") // Financial Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000010"),
                    Name = "Extortion",
                    Description = "Forcing individuals to give money or favors under threat or coercion.",
                    NameFrench = "Extorsion",
                    DescriptionFrench = "Forcer des individus à donner de l’argent ou des faveurs sous menace ou coercition.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000003") // Corruption and Influence
                },

                // 🔥 NEW INCIDENT TYPES YOU REQUESTED
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000011"),
                    Name = "Illegal Reproduction",
                    Description = "Unauthorized copying or duplication of protected documents or materials.",
                    NameFrench = "Reproduction illégale",
                    DescriptionFrench = "Copie ou duplication non autorisée de documents ou de matériels protégés.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000005") // Document and Information Crimes
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000012"),
                    Name = "Illegal Publication",
                    Description = "Publishing restricted, confidential, or unauthorized materials.",
                    NameFrench = "Publication illégale",
                    DescriptionFrench = "Publication de documents restreints, confidentiels ou non autorisés.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000005") // Document and Information Crimes
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000013"),
                    Name = "Land Dispute",
                    Description = "Conflicts involving land ownership, boundaries, or illegal occupation.",
                    NameFrench = "Conflit foncier",
                    DescriptionFrench = "Conflits liés à la propriété, aux limites ou à l’occupation illégale des terres.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000004") // Land and Property Disputes    
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000014"),
                    Name = "Falsification",
                    Description = "Altering or forging official documents, signatures, or records.",
                    NameFrench = "Falsification",
                    DescriptionFrench = "Altération ou falsification de documents, signatures ou registres officiels.",
                      IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000005") // Document and Information Crimes
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000015"),
                    Name = "Money Laundering",
                    Description = "Concealing the origins of illegally obtained money.",
                    NameFrench = "Blanchiment d’argent",
                    DescriptionFrench = "Dissimuler l’origine de fonds obtenus illégalement.",
                    IncidentCategoryId =Guid.Parse("20000000-0000-0000-0000-000000000001") // Financial Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000016"),
                    Name = "Land Grabbing",
                    Description = "Illegal acquisition or occupation of land, often through coercion or fraud.",
                    NameFrench = "Accaparement des terres",
                    DescriptionFrench = "Acquisition ou occupation illégale de terres, souvent par coercition ou fraude.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000004") // Land and Property Disputes
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000017"),
                    Name = "Hiring Favoritism",
                    Description = "Unfair hiring practices that favor certain individuals without merit.",
                    NameFrench = "Favoritisme dans le recrutement",
                    DescriptionFrench = "Pratiques d’embauche injustes favorisant certains individus sans mérite.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000002") // Administrative Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000018"),
                    Name = "Illegal Acquisition of Public Property",
                    Description = "Unauthorized possession or transfer of state-owned assets.",
                    NameFrench = "Acquisition illégale de biens publics",
                    DescriptionFrench = "Possession ou transfert non autorisé de biens appartenant à l’État.",
                    IncidentCategoryId =Guid.Parse("20000000-0000-0000-0000-000000000001") // Financial Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000019"),
                    Name = "Confiscation of Property Belonging to Others",
                    Description = "Seizing property without legal authority or due process.",
                    NameFrench = "Confiscation de biens appartenant à autrui",
                    DescriptionFrench = "Saisie de biens sans autorité légale ou procédure régulière.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000004") // Land and Property Disputes
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000020"),
                    Name = "Abuse of Personnel",
                    Description = "Mistreatment, intimidation, or exploitation of employees or subordinates.",
                    NameFrench = "Abus de personnel",
                    DescriptionFrench = "Mauvais traitements, intimidation ou exploitation d’employés ou de subordonnés.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000002") // Administrative Misconduct
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000021"),
                    Name = "Sexual Harassment",
                    Description = "Unwanted sexual advances, requests, or conduct in the workplace.",
                    NameFrench = "Harcèlement sexuel",
                    DescriptionFrench = "Avances, demandes ou comportements sexuels non désirés sur le lieu de travail.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000006") // Sexual Misconduct

                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000022"),
                    Name = "High-risk safety warning",
                    Description = "High - risk safety warning",
                    NameFrench = "Avertissement sécuritaire à haut risque",
                    DescriptionFrench = "Avertissement sécuritaire à haut risque.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000007") //High - risk safety warning
                },
                new IncidentType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000023"),
                    Name = "Unclassified - Other",
                    Description = "Unclassified - Other",
                    NameFrench = "Autre ou no classifié",
                    DescriptionFrench = "Autre ou no classifié.",
                    IncidentCategoryId = Guid.Parse("20000000-0000-0000-0000-000000000008") // High-risk safety warning
                }
            );

            // GOVERNMENT OFFICE CONFIGURATION -------------------------------------

            //CATEGORY CONFIGURATION
            modelBuilder.Entity<IncidentCategory>().HasData(
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000001"),
                    Code = "FIN",
                    Name = "Financial Misconduct",
                    NameFrench = "Infractions financières",
                    Description = "Crimes involving public funds, assets, or financial deception.",
                    DescriptionFrench = "Crimes impliquant des fonds publics, des biens ou des tromperies financières."
                },
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000002"),
                    Code = "ADM",
                    Name = "Administrative Misconduct",
                    NameFrench = "Manquements administratifs",
                    Description = "Misuse of administrative authority or violation of public duty.",
                    DescriptionFrench = "Mauvaise utilisation de l’autorité administrative ou violation du devoir public."
                },
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000003"),
                    Code = "COR",
                    Name = "Corruption and Influence",
                    NameFrench = "Corruption et influence",
                    Description = "Acts involving undue influence, bribery, or coercion.",
                    DescriptionFrench = "Actes impliquant une influence indue, des pots-de-vin ou de la coercition."
                },
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000004"),
                    Code = "PRO",
                    Name = "Land and Property Disputes",
                    NameFrench = "Litiges fonciers et immobiliers",
                    Description = "Conflicts or illegal actions involving land or property.",
                    DescriptionFrench = "Conflits ou actions illégales impliquant des terres ou des biens."
                },
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000005"),
                    Code = "DOC",
                    Name = "Document and Information Crimes",
                    NameFrench = "Crimes liés aux documents et à l’information",
                    Description = "Forgery, illegal reproduction, or unauthorized publication.",
                    DescriptionFrench = "Falsification, reproduction illégale ou publication non autorisée."
                },
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000006"),
                    Code = "SEX",
                    Name = "Sexual Misconduct",
                    NameFrench = "Inconduite sexuelle",
                    Description = "Sexual harassment or related misconduct.",
                    DescriptionFrench = "Harcèlement sexuel ou inconduite connexe."
                },
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000007"),
                    Code = "SEC",
                    Name = "High-risk safety warning",
                    NameFrench = "Avertissement sécuritaire à haut risque",
                    Description = "High-risk safety warning.",
                    DescriptionFrench = "Avertissement sécuritaire à haut risque."
                },
                new IncidentCategory
                {
                    Id = Guid.Parse("20000000-0000-0000-0000-000000000008"),
                    Code = "OTH",
                    Name = "Other",
                    NameFrench = "Autre",
                    Description = "Other",
                    DescriptionFrench = "Autre."
                }
            );

            // MaritalStatus CONFIGURATION

            modelBuilder.Entity<MaritalStatus>().HasData(
                new MaritalStatus
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Code = "SINGLE",
                    Name = "Single",
                    NameFrench = "Célibataire",
                    NameEnglish = "Single"
                },
                new MaritalStatus
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Code = "MARRIED",
                    Name = "Married",
                    NameFrench = "Marié(e)",
                    NameEnglish = "Married"
                },
                new MaritalStatus
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Code = "DIVORCED",
                    Name = "Divorced",
                    NameFrench = "Divorcé(e)",
                    NameEnglish = "Divorced"
                },
                new MaritalStatus
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    Code = "WIDOWED",
                    Name = "Widowed",
                    NameFrench = "Veuf / Veuve",
                    NameEnglish = "Widowed"
                },
                new MaritalStatus
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    Code = "SEPARATED",
                    Name = "Separated",
                    NameFrench = "Séparé(e)",
                    NameEnglish = "Separated"
                }
            );

            // GENDER CONFIGURATION -------------------------------------
            modelBuilder.Entity<Gender>().HasData(
                new Gender
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Code = "M",
                    Name = "Male",
                    NameFrench = "Homme",
                    NameEnglish = "Male"
                },
                new Gender
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Code = "F",
                    Name = "Female",
                    NameFrench = "Femme",
                    NameEnglish = "Female"
                },
                new Gender
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Code = "O",
                    Name = "Other",
                    NameFrench = "Autre",
                    NameEnglish = "Other"
                }
            );

            // SpouseType  CONFIGURATION -------------------------------------
            modelBuilder.Entity<SpouseType>().HasData(
                new SpouseType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Code = "HUSBAND",
                    Name = "Husband",
                    NameFrench = "Mari",
                    NameEnglish = "Husband"
                },
                new SpouseType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Code = "WIFE",
                    Name = "Wife",
                    NameFrench = "Femme",
                    NameEnglish = "Wife"
                },
                new SpouseType
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Code = "PARTNER",
                    Name = "Partner",
                    NameFrench = "Partenaire",
                    NameEnglish = "Partner"
                }
            );

            // Government Office  CONFIGURATION -------------------------------------

            modelBuilder.Entity<GovernmentOffice>().HasData(
                new GovernmentOffice
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Name = "Ministry of Justice",
                    Province = "Kinshasa",
                    City = "Kinshasa",
                    AddressLine = "Boulevard du 30 Juin, Gombe",
                    Email = "contact@justice.cd",
                    Phone = "+243 820 000 001"
                },
                new GovernmentOffice
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Name = "Anti-Corruption Agency (APLC)",
                    Province = "Kinshasa",
                    City = "Kinshasa",
                    AddressLine = "Avenue des Huileries, Gombe",
                    Email = "info@aplc.cd",
                    Phone = "+243 820 000 002"
                },
                new GovernmentOffice
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Name = "Provincial Governor's Office",
                    Province = "Haut-Katanga",
                    City = "Lubumbashi",
                    AddressLine = "Avenue Kasa-Vubu",
                    Email = "governor@hautkatanga.cd",
                    Phone = "+243 820 000 003"
                },
                new GovernmentOffice
                {Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    Name = "Ministry of Finance",
                    Province = "Kinshasa",
                    City = "Kinshasa",
                    AddressLine = "Boulevard du 30 Juin",
                    Email = "finance@min.cd",
                    Phone = "+243 820 000 004"
                }
            );

            // Reason Rejected  CONFIGURATION -------------------------------------
            modelBuilder.Entity<ReasonRejected>().HasData(
                new ReasonRejected
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Code = "INSUFFICIENT_INFO",
                    Name = "Insufficient Information",
                    NameFrench = "Informations insuffisantes",
                    NameEnglish = "Insufficient Information",
                    DescriptionFrench = "La plainte ne contient pas suffisamment de détails pour permettre une enquête.",
                    DescriptionEnglish = "The complaint does not contain enough detail to allow an investigation."
                },
                new ReasonRejected
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Code = "OUT_OF_SCOPE",
                    Name = "Outside Jurisdiction",
                    NameFrench = "Hors compétence",
                    NameEnglish = "Outside Jurisdiction",
                    DescriptionFrench = "La plainte ne relève pas de la compétence de l'agence.",
                    DescriptionEnglish = "The complaint does not fall under the agency's jurisdiction."
                },
                new ReasonRejected
                {Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Code = "NO_EVIDENCE",
                    Name = "No Supporting Evidence",
                    NameFrench = "Aucune preuve",
                    NameEnglish = "No Supporting Evidence",
                    DescriptionFrench = "Aucune preuve ou documentation n'a été fournie.",
                    DescriptionEnglish = "No evidence or documentation was provided."
                },
                new ReasonRejected
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    Code = "MALICIOUS",
                    Name = "Malicious or False Report",
                    NameFrench = "Rapport malveillant ou faux",
                    NameEnglish = "Malicious or False Report",
                    DescriptionFrench = "La plainte semble être intentionnellement fausse ou malveillante.",
                    DescriptionEnglish = "The complaint appears intentionally false or malicious."
                },
                new ReasonRejected
                {Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    Code = "DUPLICATE",
                    Name = "Duplicate Complaint",
                    NameFrench = "Plainte dupliquée",
                    NameEnglish = "Duplicate Complaint",
                    DescriptionFrench = "La plainte a déjà été soumise auparavant.",
                    DescriptionEnglish = "The complaint has already been submitted previously."
                }
            );


            // PaymentMethod CONFIGURATION -------------------------------------
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod
                {Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Code = "MOBILE_MONEY",
                    Name = "Mobile Money",
                    NameFrench = "Mobile Money",
                    NameEnglish = "Mobile Money",
                    DescriptionFrench = "Paiement via services mobiles tels que M-Pesa, Airtel Money, Orange Money.",
                    DescriptionEnglish = "Payment via mobile services such as M-Pesa, Airtel Money, Orange Money."
                },
                new PaymentMethod
                {Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    Code = "BANK_TRANSFER",
                    Name = "Bank Transfer",
                    NameFrench = "Virement bancaire",
                    NameEnglish = "Bank Transfer",
                    DescriptionFrench = "Paiement effectué par virement bancaire.",
                    DescriptionEnglish = "Payment made via bank transfer."
                },
                new PaymentMethod
                {Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    Code = "CASH",
                    Name = "Cash",
                    NameFrench = "Espèces",
                    NameEnglish = "Cash",
                    DescriptionFrench = "Paiement en espèces.",
                    DescriptionEnglish = "Payment in cash."
                },
                new PaymentMethod
                {Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    Code = "PAYPAL",
                    Name = "PayPal",
                    NameFrench = "PayPal",
                    NameEnglish = "PayPal",
                    DescriptionFrench = "Paiement via PayPal.",
                    DescriptionEnglish = "Payment via PayPal."
                }
            );


            // Country CONFIGURATION -------------------------------------
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    Code = "COD",
                    Name = "Democratic Republic of the Congo",
                    NameFrench = "République Démocratique du Congo",
                    NameEnglish = "Democratic Republic of the Congo"
                }
            );

            // Province CONFIGURATION -------------------------------------
            modelBuilder.Entity<Province>().HasData(
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), Code = "KIN", CountryCode = "COD", Name = "Kinshasa", NameFrench = "Kinshasa", NameEnglish = "Kinshasa" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000002"), Code = "KSU", CountryCode = "COD", Name = "Kongo Central", NameFrench = "Kongo Central", NameEnglish = "Kongo Central" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000003"), Code = "KWG", CountryCode = "COD", Name = "Kwango", NameFrench = "Kwango", NameEnglish = "Kwango" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000004"), Code = "KWL", CountryCode = "COD", Name = "Kwilu", NameFrench = "Kwilu", NameEnglish = "Kwilu" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000005"), Code = "MAI", CountryCode = "COD", Name = "Mai-Ndombe", NameFrench = "Mai-Ndombe", NameEnglish = "Mai-Ndombe" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000006"), Code = "KAS", CountryCode = "COD", Name = "Kasai", NameFrench = "Kasaï", NameEnglish = "Kasai" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000007"), Code = "KAC", CountryCode = "COD", Name = "Kasai Central", NameFrench = "Kasaï Central", NameEnglish = "Kasai Central" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000008"), Code = "KAE", CountryCode = "COD", Name = "Kasai Oriental", NameFrench = "Kasaï Oriental", NameEnglish = "Kasai Oriental" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000009"), Code = "LUA", CountryCode = "COD", Name = "Lomami", NameFrench = "Lomami", NameEnglish = "Lomami" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000010"), Code = "SUK", CountryCode = "COD", Name = "Sankuru", NameFrench = "Sankuru", NameEnglish = "Sankuru" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000011"), Code = "MAN", CountryCode = "COD", Name = "Maniema", NameFrench = "Maniema", NameEnglish = "Maniema" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000012"), Code = "SUD", CountryCode = "COD", Name = "South Kivu", NameFrench = "Sud-Kivu", NameEnglish = "South Kivu" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000013"), Code = "NKV", CountryCode = "COD", Name = "North Kivu", NameFrench = "Nord-Kivu", NameEnglish = "North Kivu" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000014"), Code = "ITU", CountryCode = "COD", Name = "Ituri", NameFrench = "Ituri", NameEnglish = "Ituri" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000015"), Code = "HAU", CountryCode = "COD", Name = "Haut-Uele", NameFrench = "Haut-Uele", NameEnglish = "Haut-Uele" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000016"), Code = "TUE", CountryCode = "COD", Name = "Tshopo", NameFrench = "Tshopo", NameEnglish = "Tshopo" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000017"), Code = "BAS", CountryCode = "COD", Name = "Bas-Uele", NameFrench = "Bas-Uele", NameEnglish = "Bas-Uele" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000018"), Code = "MBO", CountryCode = "COD", Name = "Mongala", NameFrench = "Mongala", NameEnglish = "Mongala" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000019"), Code = "NUB", CountryCode = "COD", Name = "North Ubangi", NameFrench = "Nord-Ubangi", NameEnglish = "North Ubangi" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000020"), Code = "SBU", CountryCode = "COD", Name = "South Ubangi", NameFrench = "Sud-Ubangi", NameEnglish = "South Ubangi" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000021"), Code = "EQU", CountryCode = "COD", Name = "Equateur", NameFrench = "Équateur", NameEnglish = "Equateur" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000022"), Code = "TSH", CountryCode = "COD", Name = "Tshuapa", NameFrench = "Tshuapa", NameEnglish = "Tshuapa" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000023"), Code = "LUAH", CountryCode = "COD", Name = "Haut-Lomami", NameFrench = "Haut-Lomami", NameEnglish = "Haut-Lomami" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000024"), Code = "LUAU", CountryCode = "COD", Name = "Lualaba", NameFrench = "Lualaba", NameEnglish = "Lualaba" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000025"), Code = "HAK", CountryCode = "COD", Name = "Haut-Katanga", NameFrench = "Haut-Katanga", NameEnglish = "Haut-Katanga" },
                new Province { Id = Guid.Parse("10000000-0000-0000-0000-000000000026"), Code = "TAN", CountryCode = "COD", Name = "Tanganyika", NameFrench = "Tanganyika", NameEnglish = "Tanganyika" }
            );


            // Territory CONFIGURATION -------------------------------------

            modelBuilder.Entity<Territory>().HasData(
                new Territory { Id = Guid.Parse("10000000-0000-0000-0000-000000000001"), Code = "GOM", ProvinceCode = "NKV", CountryCode = "COD", Name = "Goma" },
                new Territory { Id = Guid.Parse("10000000-0000-0000-0000-000000000002"), Code = "BEN", ProvinceCode = "NKV", CountryCode = "COD", Name = "Beni" },
                new Territory { Id = Guid.Parse("10000000-0000-0000-0000-000000000003"), Code = "RUT", ProvinceCode = "SUD", CountryCode = "COD", Name = "Uvira" },
                new Territory { Id = Guid.Parse("10000000-0000-0000-0000-000000000004"), Code = "KAS", ProvinceCode = "KAS", CountryCode = "COD", Name = "Luebo" },
                new Territory { Id = Guid.Parse("10000000-0000-0000-0000-000000000005"), Code = "KIK", ProvinceCode = "KSU", CountryCode = "COD", Name = "Mbanza-Ngungu" },
                new Territory { Id = Guid.Parse("10000000-0000-0000-0000-000000000006"), Code = "KIP", ProvinceCode = "HAK", CountryCode = "COD", Name = "Kasumbalesa" }
            );

            // City CONFIGURATION -------------------------------------

            modelBuilder.Entity<City>().HasData(
                new City { Id = Guid.Parse("30000000-0000-0000-0000-000000000001"), CountryCode = "COD", ProvinceCode = "KIN", CityName = "Kinshasa" },
                new City { Id = Guid.Parse("30000000-0000-0000-0000-000000000002"), CountryCode = "COD", ProvinceCode = "HAK", CityName = "Lubumbashi" },
                new City { Id = Guid.Parse("30000000-0000-0000-0000-000000000003"), CountryCode = "COD", ProvinceCode = "NKV", CityName = "Goma" },
                new City { Id = Guid.Parse("30000000-0000-0000-0000-000000000004"), CountryCode = "COD", ProvinceCode = "SUD", CityName = "Bukavu" },
                new City { Id = Guid.Parse("30000000-0000-0000-0000-000000000005"), CountryCode = "COD", ProvinceCode = "ITU", CityName = "Bunia" },
                new City { Id = Guid.Parse("30000000-0000-0000-0000-000000000006"), CountryCode = "COD", ProvinceCode = "TUE", CityName = "Kisangani" }
            );

            // Commune CONFIGURATION -------------------------------------

            modelBuilder.Entity<Commune>().HasData(
                new Commune { Id = Guid.Parse("40000000-0000-0000-0000-000000000001"), CityId = Guid.Parse("30000000-0000-0000-0000-000000000001"), CommuneName = "Gombe" },
                new Commune { Id = Guid.Parse("40000000-0000-0000-0000-000000000002"), CityId = Guid.Parse("30000000-0000-0000-0000-000000000001"), CommuneName = "Kinshasa" },
                new Commune { Id = Guid.Parse("40000000-0000-0000-0000-000000000003"), CityId = Guid.Parse("30000000-0000-0000-0000-000000000001"), CommuneName = "Kasa-Vubu" },
                new Commune { Id = Guid.Parse("40000000-0000-0000-0000-000000000004"), CityId = Guid.Parse("30000000-0000-0000-0000-000000000001"), CommuneName = "Lingwala" },
                new Commune { Id = Guid.Parse("40000000-0000-0000-0000-000000000005"), CityId = Guid.Parse("30000000-0000-0000-0000-000000000001"), CommuneName = "Ngaliema" }
            );

            // Quartier CONFIGURATION -------------------------------------

            modelBuilder.Entity<Quartier>().HasData(
                new Quartier { Id = Guid.Parse("50000000-0000-0000-0000-000000000001"), CommuneId = Guid.Parse("40000000-0000-0000-0000-000000000001"), Name = "Quartier Résidentiel" },
                new Quartier { Id = Guid.Parse("50000000-0000-0000-0000-000000000002"), CommuneId = Guid.Parse("40000000-0000-0000-0000-000000000001"), Name = "Quartier Commercial" }
            );

            // RoadType CONFIGURATION -------------------------------------

            modelBuilder.Entity<RoadType>().HasData(
                new RoadType { Id = Guid.Parse("50000000-0000-0000-0000-000000000001"), LookupValue = "AV", Name = "Avenue" },
                new RoadType { Id = Guid.Parse("50000000-0000-0000-0000-000000000002"), LookupValue = "BD", Name = "Boulevard" },
                new RoadType { Id = Guid.Parse("50000000-0000-0000-0000-000000000003"), LookupValue = "RT", Name = "Route" },
                new RoadType { Id = Guid.Parse("50000000-0000-0000-0000-000000000004"), LookupValue = "RN", Name = "Route Nationale" },
                new RoadType { Id = Guid.Parse("50000000-0000-0000-0000-000000000005"), LookupValue = "CH", Name = "Chaussée" },
                new RoadType { Id = Guid.Parse("50000000-0000-0000-0000-000000000006"), LookupValue = "RUE", Name = "Rue" }
            );

            // MENU CONFIGURATION -------------------------------------



            // MENU CONFIGURATION -------------------------------------


            modelBuilder.Entity<MenuItem>(e =>
            {
                e.ToTable("MenuItems");
                e.HasKey(x => x.Id);
                e.Property(x => x.Title).HasMaxLength(200).IsRequired();
                e.Property(x => x.Icon).HasMaxLength(200).IsRequired();
                e.Property(x => x.Url).HasMaxLength(400).IsRequired();
                e.Property(x => x.Role).HasMaxLength(100);
            });
            modelBuilder.Entity<MenuItem>().HasData(
                // Citizen Menu
                new MenuItem
                {
                    Id = 1,
                    Title = "Home",
                    TitleFrench = "Accueil",
                    Icon = "fa-solid fa-house",
                    Url = "/",
                    DisplayOrder = 1,
                    Role = null
                },
                new MenuItem
                {
                    Id = 2,
                    Title = "Report a Complaint",
                    TitleFrench = "Signaler une plainte",
                    Icon = "fa-solid fa-file-circle-plus",
                    Url = "/wizard",
                    DisplayOrder = 2,
                    Role = null
                },
                new MenuItem
                {
                    Id = 3,
                    Title = "Track My Complaint",
                    TitleFrench = "Suivre ma plainte",
                    Icon = "fa-solid fa-magnifying-glass",
                    Url = "/track-complaint",
                    DisplayOrder = 3,
                    Role = null
                },
                new MenuItem
                {
                    Id = 4,
                    Title = "FAQ",
                    TitleFrench = "Questions & Reponses",
                    Icon = "fa-solid fa-circle-question",
                    Url = "/faq",
                    DisplayOrder = 4,
                    Role = null
                },
                new MenuItem
                {
                    Id = 5,
                    Title = "Legal",
                    TitleFrench = "Mentions Légales",
                    Icon = "fa-solid fa-envelope",
                    Url = "/legal",
                    DisplayOrder = 5,
                    Role = null
                },
                 new MenuItem
                 {
                     Id = 6,
                     Title = "Contact",
                     TitleFrench = "Contactez-nous",
                     Icon = "fa-solid fa-envelope",
                     Url = "/contact",
                     DisplayOrder = 6,
                     Role = null
                 },
                // Staff Menu (Parent)
                new MenuItem
                {
                    Id = 10,
                    Title = "Staff",
                    TitleFrench = "Personnel",
                    Icon = "fa-solid fa-briefcase",
                    Url = "#",
                    DisplayOrder = 10,
                    Role = "Staff"
                },

                // Staff Children
                new MenuItem
                {
                    Id = 11,
                    Title = "Dashboard",
                    TitleFrench = "Tableau de bord",
                    Icon = "fa-solid fa-gauge",
                    Url = "/internal/dashboard",
                    DisplayOrder = 1,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 12,
                    Title = "Complaints",
                    TitleFrench = "Plaintes",
                    Icon = "fa-solid fa-folder-open",
                    Url = "/internal/complaints",
                    DisplayOrder = 2,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 13,
                    Title = "Assignments",
                    TitleFrench = "Attributions",
                    Icon = "fa-solid fa-user-check",
                    Url = "/internal/assignments",
                    DisplayOrder = 3,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 14,
                    Title = "Audit Logs",
                    TitleFrench = "Journaux d'audit",
                    Icon = "fa-solid fa-clipboard-list",
                    Url = "/internal/audit-logs",
                    DisplayOrder = 4,
                    ParentId = 10,
                    Role = "Staff"
                },
                new MenuItem
                {
                    Id = 15,
                    Title = "Draft Analytics",
                    TitleFrench = "Analytique des brouillons",  
                    Icon = "fa-solid fa-chart-line",
                    Url = "/internal/draft-analytics",
                    DisplayOrder = 5,
                    ParentId = 10,
                    Role = "Staff"
                },

                // Executive Menu (Parent)
                new MenuItem
                {
                    Id = 20,
                    Title = "Executive",
                    TitleFrench = "Direction",
                    Icon = "fa-solid fa-user-tie",
                    Url = "#",
                    DisplayOrder = 20,
                    Role = "Executive"
                },

                // Executive Children
                new MenuItem
                {
                    Id = 21,
                    Title = "Oversight Dashboard",
                    TitleFrench = "Tableau de bord de surveillance",
                    Icon = "fa-solid fa-chart-pie",
                    Url = "/executive/oversight",
                    DisplayOrder = 1,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 22,
                    Title = "Heatmaps",
                    TitleFrench = "Cartes de chaleur",
                    Icon = "fa-solid fa-fire",
                    Url = "/internal/draft-heatmap",
                    DisplayOrder = 2,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 23,
                    Title = "Suspicious Activity",
                    TitleFrench = "Activité suspecte",
                    Icon = "fa-solid fa-shield-halved",
                    Url = "/regulator/suspicious-activity",
                    DisplayOrder = 3,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 24,
                    Title = "Device Security Reports",
                    TitleFrench = "Rapports de sécurité des appareils",
                    Icon = "fa-solid fa-mobile-screen",
                    Url = "/regulator/device-security",
                    DisplayOrder = 4,
                    ParentId = 20,
                    Role = "Executive"
                },
                new MenuItem
                {
                    Id = 25,
                    Title = "UX Optimization Report",
                    TitleFrench = "Rapport d'optimisation UX",
                    Icon = "fa-solid fa-lightbulb",
                    Url = "/internal/ux-report",
                    DisplayOrder = 5,
                    ParentId = 20,
                    Role = "Executive"
                }
            );
        }
    }
}


//•	Either run both updates (specify the startup project) or let your deployment run dotnet ef database update per context.
//# project that contains DbContext (infrastructure) is -p; startup (API) is -s

//    # Select 'Default project' = CoAntiCor.Infrastructure in PMC
//Add-Migration AddCoreDomainEntities
//Update-Database

/*  COMMANDS TO RUN IN TERMINAL EF CORE MIGRATIONS:
 *  
1.# from solution root - CoAntiCorDbContext (project that defines the context = -p)
dotnet ef migrations add Initial_CoAntiCor \
  -c CoAntiCorDbContext \
  -p CoAntiCor.Infrastructure \
  -s CoAntiCor.API \
  -o Infrastructure/Migrations/CoAntiCor

2.# ApplicationDbContext (adjust project names as needed)
dotnet ef migrations add Initial_App \
  -c ApplicationDbContext \
  -p CoAntiCor.API \
  -s CoAntiCor.API \
  -o API/Migrations/Application

dotnet ef database update -c CoAntiCorDbContext -p CoAntiCor.Infrastructure -s CoAntiCor.API
dotnet ef database update -c ApplicationDbContext -p CoAntiCor.API -s CoAntiCor.API

/----------------------------------------------------/
PM Console:
1) 1. If both DbContexts are in the SAME project

/MyProject
   ApplicationDbContext.cs
   CoAntiCorDbContext.cs
   /Migrations
      /Identity
      /Domain

Commands:
Add-Migration InitialIdentity -Context ApplicationDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Identity"

Add-Migration InitialDomain -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"

Migrations/Identity/xxxx_InitialIdentity.cs
Migrations/Domain/xxxx_InitialDomain.cs

2. If DbContexts are in DIFFERENT projects (recommended architecture)

/CoAntiCor.API                ← Startup project
/CoAntiCor.APP           ← Contains ApplicationDbContext
/CoAntiCor.Infrastructure     ← Contains CoAntiCorDbContext

Commands:

Add-Migration InitialIdentity `
    -Context ApplicationDbContext `
    -Project CoAntiCor.Identity `
    -StartupProject CoAntiCor.API `
    -OutputDir "Migrations"

Add-Migration InitialDomain `
    -Context CoAntiCorDbContext `
    -Project CoAntiCor.Infrastructure `
    -StartupProject CoAntiCor.API `
    -OutputDir "Migrations"

This ensures:

Identity migrations go into CoAntiCor.Identity/Migrations

Domain 

///////////////////////////////////////
///
PM> Add-Migration InitialDomain -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"
PM> Update-Database -Context CoAntiCorDbContext -StartupProject CoAntiCor.API
 
PM> Add-Migration InitialIdentity -Context ApplicationDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Identity"
PM> Update-Database -Context ApplicationDbContext -StartupProject CoAntiCor.API

PM> Remove-Migration -Context ApplicationDbContext -StartupProject CoAntiCor.API

 PM> Add-Migration AddedMenuAndNewEntity -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"
PM> Update-Database -Context CoAntiCorDbContext -StartupProject CoAntiCor.API

PM> Add-Migration AddedServiceRequestEventAndNewEntity -Context CoAntiCorDbContext -StartupProject CoAntiCor.API -OutputDir "Data/Migrations/Domain"
 */