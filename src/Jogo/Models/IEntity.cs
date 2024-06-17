using System.Numerics;

/// <summary>
/// Represents an entity within the map.
/// </summary>
interface IEntity
{
	/// <summary>
	/// Gets or sets the position of the entity on the grid.
	/// </summary>
	GridVec2 Position { get; set; }

	/// <summary>
	/// Renders the entity on the specified level scene at the given coordinates.
	/// </summary>
	/// <param name="level">The level scene to render the entity on.</param>
	/// <param name="x">The x-coordinate of the entity's position on the level scene.</param>
	/// <param name="y">The y-coordinate of the entity's position on the level scene.</param>
	void Render(LevelScene level, int x, int y);

	/// <summary>
	/// Determines whether the entity can be overlapped by another entity on the specified level scene.
	/// </summary>
	/// <param name="level">The level scene to check for overlapping entities.</param>
	/// <param name="entity">The entity to check for overlapping.</param>
	/// <returns>True if the entity can be overlapped by the specified entity, otherwise false.</returns>
	bool CanOverlapedBy(LevelScene level, IEntity entity);

	/// <summary>
	/// Handles the collision between the entity and the player on the specified level scene.
	/// </summary>
	/// <param name="level">The level scene where the collision occurred.</param>
	/// <param name="player">The player entity involved in the collision.</param>
	void Collide(LevelScene level, IEntity player) { }
}
