using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KittenApi.DataLayer.Cmds.Users;
using KittenApi.DataLayer.Utils;
using KittenApi.Dtos;

namespace KittenApi.DataLayer;

public class UsersRepository
{
    private readonly DbExecuteWrapper _db;

    public UsersRepository(DbExecuteWrapper db)
        => _db = db;

    public async Task<long> InsertNewUserAsync(InsertNewUserCmd insertCmd,
        CancellationToken cancellationToken)
    {
        const string insertQuery = $@"INSERT INTO {SqlConstants.UsersTable} 
                (username, firstname, secondname, middlename, dateofbirth, description,  role)
                VALUES (@Username, @Firstname, @Secondname, @Middlename, @DateOfBirth, @Description, @Role);";

        const string getQuery = $@"SELECT id FROM {SqlConstants.UsersTable} 
                WHERE username = @Username";

        await _db.ExecuteQueryAsync(insertQuery,
            new
            {
                insertCmd.Username,
                insertCmd.Firstname,
                insertCmd.Secondname,
                insertCmd.Middlename,
                insertCmd.DateOfBirth,
                insertCmd.Description,
                Role = (int)insertCmd.Role
            },
            cancellationToken);


        return await _db.ExecuteQueryAsync<long>(getQuery, new
        {
            insertCmd.Username
        });
    }

    public async Task<User> GetUserByIdAsync(GetUserCmd getCmd, CancellationToken cancellationToken)
    {
        const string getQuery = $@"SELECT * FROM {SqlConstants.UsersTable} 
                WHERE id = @Id";

        return await _db.ExecuteQueryAsync<User>(getQuery, new
        {
            getCmd.Id
        }, cancellationToken);
    }

    public async Task<IEnumerable<User>> GetUsers(CancellationToken cancellationToken)
    {
        const string getQuery =  $@"SELECT * FROM {SqlConstants.UsersTable}";

        return await _db.MultipleExecuteQueryAsync<User>(getQuery, cancellationToken);
    }
}