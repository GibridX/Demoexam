# Содержание
1. Универсальные типы

## Универсальные типы
В C# **универсальные типы** (чаще зовут **дженериками**)позволяют определять классы, интерфейсы, методы и делегаты для типов данных, с которыми работают.

Вместо явного указания конкретного типа (например, `int` или `string`), они позвляют использовать параметр типа (традиционно называемый `T`). Фактический тип указывается при создании экземпляра класса или вызове метода.

**Пример работы:**
```csharp
private readonly AppDbContext dbContext = new();

public void Create<T>(T entity) where T : class
{
    dbContext.Add(entity);
    dbContext.SaveChanges();
}
```
В данном примере используется заполнитель `T` для метода `Create` (создание объекта в БД через EF Core);

**Применение:**
```csharp
class User 
{
    public int Id { get; set; }
    public string Role { get; set; }
    public string FullName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}

var newUser = new User { Role = "Клиент", FullName = "Иванов Иван Иванович", Login = "ivanov1@mail.ru", Password = "ivan123"};

Create<User>(newUser);
```

Здесь при вызове метода `Create` ему будет указан класс `User` и передан новый экземпляр этого класса, после чего будет выполнен запрос на создание этого объекта в таблице `users` в БД. 

Используя данный вариант решения идентично реализуются `Delete` и `Update`. Тем самым будут выполнены 3 операции из CRUD (`Create`, `Read`, `Update`, `Delete`).

### Реализация Read

Так как `Read` подразумевает под собой извлечение данных таблицы из БД и хранение полученных данных в коде для дальнейшей работы.

В следствии этого будет использоваться `List` как объект для хранения данных таблицы

```csharp
public List<T> Read<T>() where T : class
{
    return [.. dbContext.Set<T>()];
}
```

**Пояснение реализации**
```csharp
public List<T> Read<T>()
```

Здесь объявляется метод `Read<T>()` который при вызове возвращает `List<T>`.

На примере с `User`:
```csharp
var data = Read<User>();
foreach (var item in data)
{
    Console.WriteLine($"[{item.Id}]. {item.Role}, {item.FullName}, {item.Login}, {item.Password}");
}
```