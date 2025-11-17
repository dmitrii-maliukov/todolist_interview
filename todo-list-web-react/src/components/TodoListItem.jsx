import { deleteTodoList } from "../api/todoLists";
import "./TodoListItem.css";

const TodoListItem = ({ list, onDeleted }) => {

    const handleDelete = async (id) => {
        await deleteTodoList(id);
        onDeleted();
    };

    return (
        <div className="todo-list-wrapper">
            <div key={list.id} className="todo-list">

                <p className="list-title">{list.title}</p>
                {list.description && <p className="list-description">{list.description}</p>}

                <ul className="todo-items">
                    {list.todoItems.map((item) => (
                        <li key={item.id} className="todo-item-in-list">
                            <strong
                                className="item-title"
                                style={{ textDecoration: item.isCompleted ? "line-through" : "none" }}
                            >
                                {item.title}
                            </strong>
                            {item.description && <div className="item-description">{item.description}</div>}
                        </li>
                    ))}
                </ul>

            </div>

            <button
                className="remove-list-btn"
                onClick={() => handleDelete(list.id)}
                title="Delete list"
            >
                −
            </button>
        </div>
    )
};

export default TodoListItem;