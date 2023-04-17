using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Widget;

namespace mailApplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar",
    MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            // Создание кнопки ActionBarDrawerToggle и добавление ее на панель инструментов
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout,
            toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView); // Определение команд
            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += (o, e) =>
            {
                Toast.MakeText(this, "Запуск камеры", ToastLength.Long).Show();
            };
        }
        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
            e.MenuItem.SetChecked(true);
            drawerLayout.CloseDrawers();
            var menuItem = e.MenuItem;
            switch (menuItem.ItemId)
            {
                case Resource.Id.action_share:
                    Toast.MakeText(this, "Меню поделиться", ToastLength.Long).Show();
                    break;
                    case Resource.Id.save_settings:
                        Toast.MakeText(this, "Меню сохранить настройки",
                        ToastLength.Long).Show();
                        break;
                    case Resource.Id.open_camera:
                        Toast.MakeText(this, "Меню запуск камеры", ToastLength.Long).Show();
                        break;
                }
            };
        }
    }
}

