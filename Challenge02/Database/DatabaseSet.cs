// Copyright (c) Bruno Sales <me@baliestri.dev>.Licensed under the MIT License.
// See the LICENSE file in the repository root for full license text.

using Challenge02.Entities;
using Challenge02.Extensions;
using Humanizer;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Challenge02.Database;

public sealed class DatabaseSet<T> : List<T> where T : Entity {
  private readonly string _tableName;
  private readonly ILogger<DatabaseSet<T>> _logger;
  private readonly SqlConnection _connection;

  public DatabaseSet() {
    _tableName = typeof(T).Name.Pluralize();
    _logger = Program.Services.GetRequiredService<ILogger<DatabaseSet<T>>>();
    _connection = Program.Services.GetRequiredService<SqlConnection>();

    populateCollection().Wait();
  }

  public T this[Guid id] {
    get {
      var index = IndexOf(id);

      if (index == -1) {
        throw new KeyNotFoundException();
      }

      return this[index];
    }
  }

  public int IndexOf(Guid id) {
    for (var i = 0; i < Count; i++) {
      if (this[i].Id == id) {
        return i;
      }
    }

    return -1;
  }

  private Task populateCollection() {
    _logger.LogInformation("Populating collection {CollectionName}...", _tableName);
    try {
      _connection.Open();

      var command = new SqlCommand($"SELECT * FROM {_tableName}", _connection);

      var reader = command.ExecuteReader();

      while (reader.Read()) {
        var item = (T)Activator.CreateInstance(typeof(T))!;
        var properties = typeof(T).GetFilteredProperties();

        foreach (var property in properties) {
          var value = reader[property.Name];
          property.SetValue(item, value);
        }

        Add(item);
      }

      _logger.LogInformation("Collection {CollectionName} populated successfully.", _tableName);
    }
    catch (Exception e) {
      _logger.LogError(e, "An error occurred while populating the collection: '{TableName}'.", _tableName);
    }
    finally {
      _connection.Close();
    }

    return Task.CompletedTask;
  }

  public Task<bool> AddAndSave(T item) {
    _logger.LogInformation("Adding item to the collection: '{TableName}'.", _tableName);
    try {
      _connection.Open();

      var properties = typeof(T)
        .GetFilteredProperties()
        .Select(x => new KeyValuePair<string, object?>(x.Name, x.GetValue(item)))
        .ToList();

      var parameters = properties
        .Select(x => new SqlParameter($"@{x.Key}", x.Value))
        .ToList();

      var keysStr = string.Join(", ", properties.Select(x => x.Key));
      var paramsStr = string.Join(", ", properties.Select(x => $"@{x.Key}"));

      var command = new SqlCommand($"INSERT INTO {_tableName} ({keysStr}) VALUES ({paramsStr})", _connection);

      command.Parameters.AddRange(parameters.ToArray());
      var result = command.ExecuteNonQuery();

      Add(item);

      _logger.LogInformation("Item added to the collection: '{TableName}'.", _tableName);
      return Task.FromResult(result > 0);
    }
    catch (Exception e) {
      _logger.LogError(e, "An error occurred while adding an item to the collection: '{TableName}'.", _tableName);
    }
    finally {
      _connection.Close();
    }

    _logger.LogInformation("Item not added to the collection: '{TableName}'.", _tableName);
    return Task.FromResult(false);
  }

  public Task<bool> RemoveAndSave(T item) {
    _logger.LogInformation("Removing item from database: '{TableName}'.", _tableName);
    try {
      _connection.Open();

      var id = typeof(T).GetProperty("Id")?.GetValue(item);

      var parameter = new SqlParameter("@Id", id);

      var command = new SqlCommand($"DELETE FROM {_tableName} WHERE Id = @Id", _connection);
      command.Parameters.Add(parameter);

      var result = command.ExecuteNonQuery();

      Remove(item);

      _logger.LogInformation("Removed item from collection: '{TableName}'.", _tableName);
      return Task.FromResult(result > 0);
    }
    catch (Exception e) {
      _logger.LogError(e, "An error occurred while removing an item from the collection: '{TableName}'.", _tableName);
    }
    finally {
      _connection.Close();
    }

    _logger.LogInformation("Failed to remove item from collection: '{TableName}'.", _tableName);
    return Task.FromResult(false);
  }

  public Task<bool> UpdateAndSave(T item) {
    _logger.LogInformation("Updating item in database: '{TableName}'.", _tableName);
    try {
      _connection.Open();

      var properties = typeof(T)
        .GetFilteredProperties()
        .Select(x => new KeyValuePair<string, object?>(x.Name, x.GetValue(item)))
        .ToList();

      var id = properties.First(x => x.Key == "Id").Value;

      var parameters = properties
        .Except(new[ ] { properties.First(x => x.Key == "Id") })
        .Select(x => new SqlParameter($"@{x.Key}", x.Value))
        .ToList();

      var keysStr = string.Join(", ", properties.Select(x => x.Key));
      var paramsStr = string.Join(", ", properties.Select(x => $"@{x.Key}"));

      var command = new SqlCommand($"UPDATE {_tableName} SET ({keysStr}) = ({paramsStr}) WHERE Id = @Id", _connection);

      command.Parameters.AddRange(parameters.ToArray());
      var result = command.ExecuteNonQuery();

      Remove(item);
      Add(item);

      _logger.LogInformation("Updated item in collection: '{TableName}'.", _tableName);
      return Task.FromResult(result > 0);
    }
    catch (Exception e) {
      _logger.LogError(e, "An error occurred while updating an item from the collection: '{TableName}'.", _tableName);
    }
    finally {
      _connection.Close();
    }

    _logger.LogInformation("Failed to update item in collection: '{TableName}'.", _tableName);
    return Task.FromResult(false);
  }
}
