class_name ClassButNoExtend

@onready var _game_startup : GameStartup = get_node(game_startup)
@export_node_path("GameStartup") var game_startup: NodePath

func _ready() -> void:
	configure.connect(on_configure)