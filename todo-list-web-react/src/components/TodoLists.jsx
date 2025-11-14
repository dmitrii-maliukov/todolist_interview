import { useInfiniteQuery } from "@tanstack/react-query";
import { getTodoLists } from "../api/todoLists";
import TodoListItem from "./TodoListItem"
import "./TodoLists.css";

const PAGE_SIZE = 10;

const TodoLists = ({ onListDeleted }) => {
    const {
        data,
        isLoading,
        isError,
        fetchNextPage,
        hasNextPage,
        isFetchingNextPage,
        error
    } = useInfiniteQuery({
        queryKey: ["todoLists"],
        queryFn: ({ pageParam = 1 }) => getTodoLists(PAGE_SIZE, pageParam),
        getNextPageParam: (lastPage, allPages) => {
            const currentPage = lastPage.currentPageNumber;
            const totalPages = Math.ceil(lastPage.totalCount / PAGE_SIZE);
            return currentPage < totalPages ? currentPage + 1 : undefined;
        },
        keepPreviousData: true,
    });

    if (isLoading) return <div className="loading">Loading...</div>;
    if (isError) return <div className="error">Error: {error.message}</div>;

    return (
        <div className="todo-container">
            {data.pages.map((page) =>
                page.items.map((list) => (
                    <TodoListItem key={list.id} list={list} onDeleted={onListDeleted} />
                ))
            )}

            {hasNextPage && (
                <div className="load-more-container">
                    <button
                        className="load-more-btn"
                        onClick={() => fetchNextPage()}
                        disabled={isFetchingNextPage}
                    >
                        {isFetchingNextPage ? "Loading..." : "Load More"}
                    </button>
                </div>
            )}
        </div>
    );
};

export default TodoLists;