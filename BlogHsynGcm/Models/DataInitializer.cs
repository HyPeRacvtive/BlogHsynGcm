using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogHsynGcm.Models
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            DataContext Context = new DataContext();

            var User = new List<Users>()
            {
                new Users() {NameSurName="Vehbi İlkan MEMİLİ",Image="user.png",Mail="ilkkanml@outlook.com",Password="1"},
                new Users() {NameSurName="Mehmet GÖN",Image="user.png",Mail="mehmetggon@gmail.com",Password="1"},
                new Users() {NameSurName="Açelya MEMİLİ",Image="user.png",Mail="ilkkanml@outlook.com",Password="1"},
                new Users() {NameSurName="Pınar GÖN",Image="user.png",Mail="mehmetggon@gmail.com",Password="1"},
            };
            foreach (var us in User)
            {
                context.Users.Add(us);

            }
            context.SaveChanges();
            base.Seed(context);
            var Writer = new List<Writers>()
            {
                new Writers(){NameSurname="Hüseyin GÜCÜM",Mail="huseyingucum@hotmail.com",About="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. ",Password="12",Image="huseyingucum.jpg",AboutHeader="Gelecek Tecrübeyle Şekillenecek",Address="Adana/Ceyhan",Phone="0 (123) 456 78 90",ShortAbout="Elinden geleni yapmak keyfi bir davranıştır. Türkiye Cumhuriyeti vatandaşı olarak üzerimize düşeni yapmalıyız. Benim, Hüseyin GÜCÜM olarak, Üzerime düşen asli görevimin, ülkemizin sanayi alanında üretimini arttırarak, dışa bağımlılığı azaltmak ve gelecek nesillere ışık tutmak olduğu kanaatindeyim.",UserName="Hüseyin"}
            };
            foreach (var Wrt in Writer)
            {
                context.Writers.Add(Wrt);
            }
            context.SaveChanges();
            base.Seed(Context);
            var Category = new List<Categories>()
            {
                new Categories() {Name="Tarımsal Üretim",Color="#FF2D00"},
                new Categories() {Name="Tarım Makinaları",Color="#4EFF00"},
                new Categories() {Name="Güncel Politika",Color="#0063FF"},
                new Categories() {Name="Politik Haberler",Color="#FCFF00"},
            };
            foreach (var Cat in Category)
            {
                context.Categories.Add(Cat);

            }
            context.SaveChanges();
            base.Seed(context);
            var Blog = new List<Blogs>()
            {
                new Blogs() {Header="Başlık 1 Lorem ipsum dolor sit respect.", BlogContent="İçerik 1 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=1,WritersId =1,Image="Blogs1.jpg",isSlider=false,isEditorschoice=false,LikeCount=21,isActive=false},
                new Blogs() {Header="Başlık 2 Lorem ipsum dolor sit respect.", BlogContent="İçerik 2 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=2,WritersId =1,Image="Blogs2.jpg",isSlider=true,isEditorschoice=false,LikeCount=32,isActive=true},
                new Blogs() {Header="Başlık 3 Lorem ipsum dolor sit respect.", BlogContent="İçerik 3 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=3,WritersId =1,Image="Blogs3.jpg",isSlider=false,isEditorschoice=true,LikeCount=18,isActive=false},
                new Blogs() {Header="Başlık 4 Lorem ipsum dolor sit respect.", BlogContent="İçerik 4 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=4,WritersId =1,Image="Blogs4.jpg",isSlider=false,isEditorschoice=true,LikeCount=41,isActive=true},
                    new Blogs() {Header="Başlık 5 Lorem ipsum dolor sit respect.", BlogContent="İçerik 5 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=1,WritersId =1,Image="Blogs1.jpg",isSlider=false,isEditorschoice=true,LikeCount=144,isActive=true},
                new Blogs() {Header="Başlık 6 Lorem ipsum dolor sit respect.", BlogContent="İçerik 6 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=2,WritersId =1,Image="Blogs5.jpg",isSlider=true,isEditorschoice=false,LikeCount=59,isActive=true},
                new Blogs() {Header="Başlık 7 Lorem ipsum dolor sit respect.", BlogContent="İçerik 7 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=3,WritersId =1,Image="Blogs6.jpg",isSlider=false,isEditorschoice=false,LikeCount=97,isActive=true},
                new Blogs() {Header="Başlık 8 Lorem ipsum dolor sit respect.", BlogContent="İçerik 8 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=4,WritersId =1,Image="Blogs7.jpg",isSlider=true,isEditorschoice=true,LikeCount=234,isActive=false},
                    new Blogs() {Header="Başlık 9 Lorem ipsum dolor sit respect.", BlogContent="İçerik 9 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=1,WritersId =1,Image="Blogs8.jpg",isSlider=false,isEditorschoice=true,LikeCount=681,isActive=true},
                new Blogs() {Header="Başlık 10 Lorem ipsum dolor sit respect.", BlogContent="İçerik 10 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=2,WritersId =1,Image="Blogs9.jpg",isSlider=true,isEditorschoice=true,LikeCount=4,isActive=true},
                new Blogs() {Header="Başlık 11 Lorem ipsum dolor sit respect.", BlogContent="İçerik 11 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=3,WritersId =1,Image="Blogs3.jpg",isSlider=false,isEditorschoice=false,LikeCount=965,isActive=true},
                new Blogs() {Header="Başlık 12 Lorem ipsum dolor sit respect.", BlogContent="İçerik 12 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=4,WritersId =1,Image="Blogs2.jpg",isSlider=true,isEditorschoice=true,LikeCount=77,isActive=false},
                new Blogs() {Header="Başlık 13 Lorem ipsum dolor sit respect.", BlogContent="İçerik 12 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=4,WritersId =1,Image="Blogs5.jpg",isSlider=true,isEditorschoice=true,LikeCount=391,isActive=true},
                  new Blogs() {Header="Başlık 13 Lorem ipsum dolor sit respect.", BlogContent="İçerik 12 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor. Integer nec lacinia augue. Curabitur mattis vel orci id mattis. Aliquam eu dignissim sem. Interdum et malesuada fames ac ante ipsum primis in faucibus. Mauris vitae fermentum quam.Lorem ipsum dolor sit respect, conse ctetur adipiscing elit. Sed maximus orci ac condi mentum efficitur. Suspendi potenti. Fusce diam felis, ullamcor aca felis sed, volutpat varius tortor. Ut eleifend justo sed quam blandit, vehicula ante hendrerit. Sed condimentum libero vel eros porta, eu malesuada nulla bibendum. Proin varius sollicitudin nulla quis fermentum. Nunc vitae arcu eget diam gravida ultrices finibus nec mi. Maecenas egestas libero.",CategoriesId=3,WritersId =1,Image="Blogs2.jpg",isSlider=true,isEditorschoice=false,LikeCount=21,isActive=true},
            };
            foreach (var Art in Blog)
            {
                context.Blogs.Add(Art);

            }
            context.SaveChanges();
            base.Seed(context);
            var Comment = new List<Comments>()
            {
                new Comments() {Comment="Yorum 1 ÇDonec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId=1,BlogId=1,isActive=true},
                new Comments() {Comment="Yorum 2 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId =2,BlogId=2,isActive=true},
                new Comments() {Comment="Yorum 3 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId=1,BlogId=6,isActive=true},
                new Comments() {Comment="Yorum 4 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId =3,BlogId=3,isActive=true},
                 new Comments() {Comment="Yorum 5 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId=4,BlogId=4,isActive=true},
                new Comments() {Comment="Yorum 6 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId =4,BlogId=4,isActive=true},
                new Comments() {Comment="Yorum 7 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId=1,BlogId=7,isActive=true},
                new Comments() {Comment="Yorum 8 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId =2,BlogId=8,isActive=true},
                new Comments() {Comment="Yorum 9 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId=1,BlogId=7,isActive=true},
                new Comments() {Comment="Yorum 10 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId =3,BlogId=9,isActive=true},
                 new Comments() {Comment="Yorum 11 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId=4,BlogId=11,isActive=true},
                new Comments() {Comment="Yorum 12 Donec ultricies convallis urna. Morbi consequat vestibulum nunc sed semper. Proin iaculis risus eleifend, efficitur eros et, tristique tortor.",UsersId =4,BlogId=12,isActive=true},
            };
            foreach (var cmmnt in Comment)
            {
                context.Comments.Add(cmmnt);

            }
            context.SaveChanges();
            base.Seed(context);
            var Social = new List<SocialFeed>()
            {
                new SocialFeed() {FaceBook="https://www.facebook.com/gucumhuseyin",Instagram="https://www.instagram.com/gucumhuseyin",Twitter="https://twitter.com/gucumhuseyin",LinkEdIn="https://www.linkedin.com/in/gucumhuseyin"}

            };
            foreach (var Soc in Social)
            {
                context.SocialFeed.Add(Soc);

            }
            context.SaveChanges();
            base.Seed(context);
            var Setting = new List<Settings>()
            {
                new Settings() {Logo="logo.png",VisitorCount=1500,LogoHeight=50,LogoWidth=50}

            };
            foreach (var stt in Setting)
            {
                context.Settings.Add(stt);

            }
            context.SaveChanges();
            base.Seed(context);


        }
    }
}