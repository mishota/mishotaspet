using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using MishDomain.MyModels;



namespace MishPets.Models
{
    // Чтобы добавить данные профиля для пользователя, можно добавить дополнительные свойства в класс ApplicationUser. Дополнительные сведения см. по адресу: http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Адрес")]
        public string Address { get; set; } //Добавляем поле адрес
        [Display(Name = "Телефон")]
        public string Phone { get; set; } //Добавляем поле телефон
        [Required]
        [Display(Name = "Передержка (1) ")]
        [Range(typeof(int), "0", "1")]
        public int FlagОverexposure { get; set; } // Добавляем поле флаг передержки
        [Display(Name = "Долгота")]
        public double GeoLong { get; set; } // долгота - для карт google
        [Display(Name = "Широта")]
        public double GeoLat { get; set; } // широта - для карт google

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }

    }

    //Добавляем модель KindOfPet
    public partial class KindOfPet
    {
        public KindOfPet()
        {
            this.Pets = new List<Pet>();
        }
        
        public int KindOfPetId { get; set; }
        [Display(Name = "Вид животного")]
        public string Kind { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }
    }
    //Добавляем модель Pet
    public class Pet
    {
        public Pet()
        {
            this.NewHomeContracts = new List<NewHomeContract>();
            this.OverexposureContracts = new List<OverexposureContract>();
        }

        public int PetId { get; set; }
        public int KindOfPetId { get; set; }
        [Display(Name = "Кличка")]
        public string NickName { get; set; }
        [Display(Name = "Возраст (мес)")]
        public int Age { get; set; }
        [Display(Name = "Описание")]
        public string DescriptionOfPet { get; set; }
        [Display(Name = "Пол")]
        [Range(typeof(int), "0", "1")]
        public int FlagMale { get; set; }
        [Display(Name = "Статус")]
        public string StatusOfPet { get; set; }
        [Display(Name = "Фото")]
        public byte[] ImagePet { get; set; }
        public string ImageMimeType { get; set; }

        public virtual KindOfPet KindOfPet { get; set; }
        public virtual ICollection<NewHomeContract> NewHomeContracts { get; set; }
        public virtual ICollection<OverexposureContract> OverexposureContracts { get; set; }
    }


    //Модель NewHomeContract
    public class NewHomeContract
    {
        [Display(Name = "№ договора приема")]
        public int NewHomeContractId { get; set; }
        public int PetId { get; set; }
        //public string ApplUser_Id { get; set; }
        [Display(Name = "Дата")]
        public System.DateTime DateHomeStart { get; set; }
        [Display(Name = "ID пользователя")]
        public string IdUserForNewHome { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Pet Pet { get; set; }
    }

    //Модель OverexposureContract
    public class OverexposureContract
    {
        public OverexposureContract()
        {
            this.Invoices = new List<Invoice>();
            this.Payments = new List<Payment>();
        }
        [Display(Name = "№ договора передержки")]
        public int OverexposureContractId { get; set; }
        public int PetId { get; set; }
        //public string ApplicationUser_Id { get; set; }
        [Display(Name = "Дата принятия на передержку")]
        public System.DateTime DateOverexpStart { get; set; }
        [Display(Name = "Дата окончания передержки")]
        public System.DateTime? DateOverexpEnd { get; set; }
        [Display(Name = "ID пользователя")]
        public string IdUserForOverexp { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }


    public partial class BlogPost
    {
        public int BlogPostId { get; set; }
        public string ApplicationUser_Id { get; set; }
        //public string Id { get; set; }
        [Display(Name = "Дата")]
        public System.DateTime DatetimeBlogPost { get; set; }
        [Display(Name = "Текст сообщения")]
        public string TextOfPost { get; set; }
        [Display(Name = "Фото")]
        public byte[] ImagePost { get; set; }
        public string ImagePostMimeType { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public partial class Invoice
    {
        public Invoice()
        {
            this.Expense_Invoices = new List<Expense_Invoice>();
        }
        [Display(Name = "№ счета")]
        public int InvoiceId { get; set; }//
        public int OverexposureContractId { get; set; }//
        [Display(Name = "Дата счета")]
        public System.DateTime DateOfInvoice { get; set; }
        [Display(Name = "Сумма счета")]
        public double? SumOfInvoice { get; set; }

        public virtual ICollection<Expense_Invoice> Expense_Invoices { get; set; }
        public virtual OverexposureContract OverexposureContracts { get; set; }
    }


    public partial class Expense_Invoice
    {
        public int Expense_InvoiceId { get; set; }
        public int InvoiceId { get; set; }
        public int OverexposureContractId { get; set; }//
        public int ExpenseId { get; set; }
        [Required]
        [Display(Name = "Количество")]
        [Range(typeof(int), "0", "10", ErrorMessage = "Недопустимое значение")]
        public int Quantity { get; set; }
        [Display(Name = "Сумма")]
        public double? SumExpense { get; set; }

        public virtual Expense Expense { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
    public partial class Expense
    {
        public Expense()
        {
            this.Expense_Invoices = new List<Expense_Invoice>();
        }
        public int ExpenseId { get; set; }
        [Display(Name = "Тип расходов")]
        public string TypeOfExpense { get; set; }
        [Display(Name = "Стоимость расходов")]
        public double CostOfExpense { get; set; }
        public virtual ICollection<Expense_Invoice> Expense_Invoices { get; set; }
    }

    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int OverexposureContractId { get; set; }
        [Display(Name = "Сумма платежа")]
        public double SumOfPayment { get; set; }
        [Display(Name = "Дата платежа")]
        public System.DateTime DateOfPayment { get; set; }

        public virtual OverexposureContract OverexposureContracts { get; set; }
    }



    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<KindOfPet> KindOfPets { get; set; }
        public DbSet<NewHomeContract> NewHomeContracts { get; set; }
        public DbSet<OverexposureContract> OverexposureContracts { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Expense_Invoice> Expense_Invoices { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(this));
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(this));

            //// создаем две роли
            //var role1 = new IdentityRole { Name = "admin" };
            //var role2 = new IdentityRole { Name = "user" };
            //var role3 = new IdentityRole { Name = "over" };

            //// добавляем роли в бд
            //roleManager.Create(role1);
            //roleManager.Create(role2);
            //roleManager.Create(role3);

            //// создаем пользователей
            //var admin = new ApplicationUser { Email = "ksu_a@mail.ru", UserName = "ksu_a@mail.ru" };
            //string password = "jrcfy84";
            //var result = userManager.Create(admin, password);

            //// если создание пользователя прошло успешно
            //if (result.Succeeded)
            //{
            //    // добавляем для пользователя роль
            //    userManager.AddToRole(admin.Id, role1.Name);
            //    userManager.AddToRole(admin.Id, role2.Name);
            //    userManager.AddToRole(admin.Id, role3.Name);
            //}

            //base.Seed(context);



            //var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(this));
            //var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(this));
            //IdentityResult createUserResult = null; IdentityResult createRoleResult = null;
            //var user = userManager.FindByName("ksu_a@mail.ru ");
            //var role = roleManager.FindByName("admin");
            //if (role == null)
            //{
            //    role = new IdentityRole { Name = "admin" };
            //    createRoleResult = roleManager.Create(role);
            //}
            //if (createUserResult != null && createUserResult.Succeeded)
            //    if (createRoleResult.Succeeded)
            //        userManager.AddToRole(user.Id.ToString(), "admin");
            //role = roleManager.FindByName("user");
            //if (role == null)
            //{
            //    roleManager.Create(new IdentityRole { Name = "user" });
            //}
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<MishPets.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}