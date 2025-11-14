import React, { useState } from "react";
import { addTodoList } from "../api/todoLists";
import "./AddTodoList.css";

const AddTodoList = ({ onSuccess, onClose }) => {
    const [title, setTitle] = useState("");
    const [description, setDescription] = useState("");
    const [items, setItems] = useState([{ title: "", description: "", isCompleted: false }]);
    const [submitting, setSubmitting] = useState(false);
    const [error, setError] = useState(null);

    const handleItemChange = (index, field, value) => {
        const copy = [...items];
        copy[index][field] = value;
        setItems(copy);
    };

    const addItem = () => setItems([...items, { title: "", description: "", isCompleted: false }]);
    const removeItem = (index) => setItems(items.filter((_, i) => i !== index));

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(null);
        if (!title.trim()) {
            alert("List title is required!");
            return;
        }
        const filteredItems = items.filter((it) => it.title.trim() !== "");
        const payload = { title, description, todoItems: filteredItems };
        try {
            setSubmitting(true);
            await addTodoList(payload);
            setTitle("");
            setDescription("");
            setItems([{ title: "", description: "", isCompleted: false }]);
            if (onSuccess) onSuccess();
        } catch (err) {
            setError(err.message || "Failed to add ToDo list");
        } finally {
            setSubmitting(false);
        }
    };

    return (
        <form className="add-form" onSubmit={handleSubmit}>
            {error && <div className="form-error">{error}</div>}

            <div className="row grid-two-columns">
                <div className="field">
                    <label className="field-label">* Todo List Name:</label>
                    <input
                        className="single-input"
                        value={title}
                        onChange={(e) => setTitle(e.target.value)}
                        required
                        type="text"
                        placeholder="My list name"
                    />
                </div>

                <div className="field">
                    <label className="field-label">Description:</label>
                    <div className="right-content">
                        <textarea
                            className="multi-input-top"
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            rows={3}
                            placeholder="Optional description of the list"
                        />
                    </div>
                </div>
            </div>

            {items.map((item, idx) => (
                <div key={idx} className="row grid-two-columns item-row">
                    <div className="field">
                        <label className="field-label">* Todo Item:</label>
                        <input
                            className="single-input"
                            value={item.title}
                            onChange={(e) => handleItemChange(idx, "title", e.target.value)}
                            required
                            type="text"
                            placeholder="Item title"
                        />
                    </div>

                    <div className="field">
                        <label className="field-label">Note:</label>
                        <div className="right-content with-button">
                            <textarea
                                className="multi-input note-input"
                                value={item.description}
                                onChange={(e) => handleItemChange(idx, "description", e.target.value)}
                                rows={3}
                                placeholder="Optional note"
                            />
                            <div className="right-action stacked-buttons">
                                <button
                                    type="button"
                                    className="icon-button remove-button color-button"
                                    onClick={() => removeItem(idx)}
                                >
                                    −
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            ))}

            <div className="row add-row">
                <button type="button" className="icon-button add-button color-button" onClick={addItem}>
                    Add Todo Item
                </button>
            </div>

            <div className="row actions-row">
                <div />
                <div className="actions-right">
                    <button type="button" className="cancel-button slider-button" onClick={onClose}>
                        Cancel
                    </button>

                    <button
                        type="submit"
                        className="submit-button slider-button color-button"
                        disabled={submitting}
                    >
                        {submitting ? "Saving..." : "Submit"}
                    </button>
                </div>
            </div>
        </form>
    );
};

export default AddTodoList;
