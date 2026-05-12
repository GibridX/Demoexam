# Рекомендации
Здесь будут записаны рекомендации и советы по подготовки и изучению.

1. [LINQ](#linq)
1. [EntityFrameworkCore](#ef)

<a id="linq"></a>
## LINQ (Language Integrated Query)
> [LINQ](https://metanit.com/sharp/tutorial/15.1.php) в сочетании с Entity Framework позволяет разработчикам создавать запросы к концептуальной модели Entity Framework с использованием синтаксиса C#. Эта технология называется LINQ to Entities.

#### Основные принципы работы
[LINQ to Entities](https://metanit.com/sharp/entityframework/4.1.php) преобразует запросы LINQ в запросы, понятные для базы данных (обычно в SQL), которые выполняются на сервере. 
При этом Entity Framework абстрагируется от конкретных особенностей базы данных, рассматривая данные как объекты.

#### Пример кода
```csharp
using (var db = new AppDbContext())
{
    // Данные в базе (условно):
    // 1. iPhone 15 - 90 000 (Электроника)
    // 2. Чайник - 3 000 (Кухня)
    // 3. MacBook Air - 120 000 (Электроника)
    // 4. Наушники - 15 000 (Электроника)

    var highEndElectronics = db.Products
        .Where(p => p.Category == "Electronics" && p.Price > 50000) // Фильтрация
        .OrderByDescending(p => p.Price)                             // Сортировка
        .Select(p => new { p.Title, p.Price })                      // Выбираем только нужные поля
        .ToList();                                                  // Выполнение запроса

    // Вывод результата
    Console.WriteLine("Премиальная электроника:");
    foreach (var item in highEndElectronics)
    {
        Console.WriteLine($"- {item.Title}: {item.Price:N0} руб.");
    }
}
```

#### Что выполнится
Entity Framework переведет этот C#-код в SQL-запрос и отправит его в базу:
```sql
SELECT Title, Price 
FROM Products 
WHERE Category = 'Electronics' AND Price > 50000 
ORDER BY Price DESC
```

#### Вывод в консоль
```text
Премиальная электроника:
- MacBook Air: 120 000 руб.
- iPhone 15: 90 000 руб.
```

> Обратите внимание: благодаря методу .Select(), мы создали анонимный тип. Это полезно в LINQ to Entities, так как база данных вернет только два столбца вместо всей таблицы.

## EntityFrameworkCore (PostgreSQl)
Для работы с PostgreSQL через EntityFrameworkCore (сокр. EF), используется пакет **EntityFrameworkCore.PostgreSQL**

#### Пример работы
1. **Определение модели и контекста**
```csharp
using Microsoft.EntityFrameworkCore;

// Модель данных
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

// Контекст базы данных
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=имя_базы_данных;Username=postgres;Password=пароль_пользователя_postgres");
    }
}
```

2. **Использование (CRUD пример)**
Ниже представлен код для создания базы данных, добавления записи и её последующего чтения.
```csharp
using (AppDbContext db = new AppDbContext())
{
    // Если таблица существует и в ней есть таблицы, никаких действий не выполнится
    // db.Database.EnsureCreated()

    // 1. Добавление данных
    User tom = new User { Name = "Tom", Age = 33 };
    db.Users.Add(tom);
    db.SaveChanges(); // Сохраняет изменения в БД

    // 2. Получение данных через LINQ
    var users = db.Users
        .Where(u => u.Age > 30)
        .OrderBy(u => u.Name)
        .ToList();

    Console.WriteLine("Список пользователей (старше 30):");
    foreach (var user in users)
    {
        Console.WriteLine($"{user.Id}. {user.Name} - {user.Age} лет");
    }
}
```

#### Результат
```text
Список пользователей (старше 30):
1. Tom - 33 лет
```
