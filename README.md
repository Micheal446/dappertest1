|--------|----------|-------------|---------|--------|
| GET | /api/VideoGames | Get all video games | 200 OK | — |
| GET | /api/VideoGames/{id} | Get a video game by id | 200 OK | — |
| POST | /api/VideoGames | Create a new video game | 201 Created | 400 |
| PUT | /api/VideoGames/{id} | Update an existing video game | 204 No Content | 400, 404 |
| DELETE | /api/VideoGames/{id} | Delete a video game | 204 No Content | 404 |

---

## 📨 Request & Response Examples

### Get all video games

GET /api/VideoGames
```json
[
  {
    "id": 1,
    "title": "The Legend of Zelda",
    "publisher": "Nintendo",
    "developer": "Nintendo EPD",
    "releaseDate": "2017-03-03"
  }
]

### Create a video game

http
POST /api/VideoGames
Content-Type: application/json


json
{
  "title": "Elden Ring",
  "publisher": "Bandai Namco",
  "developer": "FromSoftware",
  "releaseDate": "2022-02-25"
}

**Response:** `201 Created` with a `Location` header pointing to the new resource.

### Update a video game

http
PUT /api/VideoGames/1
Content-Type: application/json


json
{
  "id": 1,
  "title": "Elden Ring: Shadow of the Erdtree",
  "publisher": "Bandai Namco",
  "developer": "FromSoftware",
  "releaseDate": "2024-06-21"
}

**Response:** `204 No Content`

> ⚠️ The `id` in the body must match the `id` in the URL, otherwise the API returns `400 Bad Request`.

### Delete a video game

http
DELETE /api/VideoGames/1

**Response:** `204 No Content` (or `404 Not Found` if it doesn't exist)

---

## 🗡 Dapper Concepts Used

| Concept | Where it's used |
|---------|-----------------|
| `QueryAsync<T>` | Get all video games |
| `QueryFirstOrDefaultAsync<T>` | Get a single video game |
| `ExecuteScalarAsync<int>` | Insert and return the new id |
| `ExecuteAsync` | Update and delete |
| Anonymous parameters | `new { Id = id }` |
| Multi-mapping + `splitOn` | Joining normalized tables |
| Repository Pattern | `IVideoGameRepository` |

### Repository example

csharp
public async Task<VideoGame?> GetVideoGameAsync(int id)
{
    using var connection = new SqlConnection(_connectionString);

    return await connection.QueryFirstOrDefaultAsync<VideoGame>(
        "SELECT * FROM VideoGames WHERE Id = @Id",
        new { Id = id });
}
`

---

## ✨ Best Practices Applied

- Controller only interface*interface** (`IVideoGameRepository`), making it easy to test and swap.
- Eveparameterizedameterized**.
- Connections are disposed with `using`.
- Existence is checked before update and delete to return a correct `404`.

---

## 🤝 Contributing

1. Fork the repo
2. Create a feature branch: `git checkout -b feature/my-feature`
3. Commit your changes: `git commit -m "Add my feature"`
4. Push the branch: `git push origin feature/my-feature`
5. Open a Pull Request

---

##Micheal446Micheal446** — [GitHub](https://github.com/Micheal446)

⭐ If you found this project useful, give it a star!
