using System.Reflection.Metadata;
using System.Linq;
using Raylib_cs;

/// <summary>
/// Represents a game map that contains fixed and movable entities.
/// </summary>
class Map
{

    /// <summary>
    /// Gets the number of rows in the map.
    /// </summary>
    public int Rows { get; }


    /// <summary>
    /// Gets the number of columns in the map.
    /// </summary>
    public int Columns { get; }

    /// <summary>
    /// Gets all entities on the map.
    /// </summary>
    public List<IEntity> Entities { get; private init; }


    /// <summary>
    /// Gets the entities at the specified position on the map.
    /// </summary>
    /// <param name="i">The row index.</param>
    /// <param name="j">The column index.</param>
    /// <returns>The entities at the specified position.</returns>
    public IEnumerable<IEntity> this[int i, int j]
    {
        get
        {
            if (0 > i || i >= Rows)
                throw new IndexOutOfRangeException();
            if (0 > j || j >= Columns)
                throw new IndexOutOfRangeException();
            foreach (var entity in Entities)
                if (entity.Position.i == i && entity.Position.j == j)
                    yield return entity;
        }
    }

    /// <summary>
    /// Gets the entities at the specified position on the map.
    /// </summary>
    /// <param name="pos">The position.</param>
    /// <returns>The entities at the specified position.</returns>
    public IEnumerable<IEntity> this[GridVec2 pos] => this[pos.i, pos.j];

    /// <summary>
    /// Initializes a new instance of the <see cref="Map"/> class.
    /// </summary>
    /// <param name="fixedEntities">The fixed entities on the map.</param>
    /// <param name="movableEntities">The movable entities on the map.</param>
    public Map(int rows, int collumns, IEnumerable<IEntity> entities)
    {

        this.Entities = entities.Where(e => e != null).ToList();
        Rows = rows;
        Columns = collumns;
    }
}