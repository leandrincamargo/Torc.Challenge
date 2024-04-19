import React, { useEffect, useState } from 'react';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TablePagination,
  TableHead,
  TableRow,
  Paper,
  IconButton,
  Tooltip,
} from '@mui/material';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import RemoveCircleOutlineIcon from '@mui/icons-material/RemoveCircleOutline';

import { Book } from './types/Books.types';

import api from '../services/api';

const DefaultParams = { page: 0 };

interface BookListData {
  booksData: Book[];
  setLoading: React.Dispatch<React.SetStateAction<boolean>>;
  onSearchBooks: (newPage: number, newRowsPerPage: number) => Promise<void>;
  page: number;
  setPage: React.Dispatch<React.SetStateAction<number>>;
  rowsPerPage: number;
  setRowsPerPage: React.Dispatch<React.SetStateAction<number>>;
  totalItems: number;
  onEditBook: (book: Book) => void;
}

const SearchResultsTable: React.FC<BookListData> = ({
  booksData,
  setLoading,
  onSearchBooks,
  page,
  setPage,
  rowsPerPage,
  setRowsPerPage,
  totalItems,
  onEditBook,
}) => {
  const onChangePage = (event: any, newPage: number) => {
    setPage(newPage);
    onSearchBooks(newPage, rowsPerPage);
  };

  const onChangeRowsPerPage = (event: any) => {
    setRowsPerPage(+event.target.value);
    setPage(DefaultParams.page);
    onSearchBooks(DefaultParams.page, +event.target.value);
  };

  const onIncreaseCopies = async (book: Book) => {
    setLoading(true);
    book.copiesInUse++;
    try {
      await api.put(`/api/books/${book.bookId}`, book);
    } catch (e) {
      console.error(e);
    }
    setLoading(false);
    await onSearchBooks(page, rowsPerPage);
  };

  const onDecreaseCopies = async (book: Book) => {
    setLoading(true);
    book.copiesInUse--;
    try {
      await api.put(`/api/books/${book.bookId}`, book);
    } catch (e) {
      console.error(e);
    }
    setLoading(false);
    await onSearchBooks(page, rowsPerPage);
  };

  return (
    <Paper>
      <Table aria-label="search results table">
        <TableContainer>
          <TableHead>
            <TableRow>
              <TableCell style={{ fontWeight: 'bold' }}>Book Title</TableCell>
              <TableCell style={{ fontWeight: 'bold' }}>Authors</TableCell>
              <TableCell style={{ fontWeight: 'bold' }}>Type</TableCell>
              <TableCell style={{ fontWeight: 'bold' }}>ISBN</TableCell>
              <TableCell style={{ fontWeight: 'bold' }}>Category</TableCell>
              <TableCell style={{ fontWeight: 'bold' }}>
                Available Copies
              </TableCell>
              <TableCell style={{ fontWeight: 'bold' }}>Action</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {booksData.map((book, index) => (
              <TableRow key={index}>
                <TableCell>{book.title}</TableCell>
                <TableCell>{`${book.firstName} ${book.lastName}`}</TableCell>
                <TableCell>{book.type}</TableCell>
                <TableCell>{book.isbn}</TableCell>
                <TableCell>{book.category}</TableCell>
                <TableCell>{`${book.copiesInUse} / ${book.totalCopies}`}</TableCell>
                <TableCell>
                  <Tooltip title="Increase copies">
                    <IconButton onClick={() => onIncreaseCopies(book)}>
                      <AddCircleOutlineIcon />
                    </IconButton>
                  </Tooltip>
                  <Tooltip title="Decrease copies">
                    <IconButton onClick={() => onDecreaseCopies(book)}>
                      <RemoveCircleOutlineIcon />
                    </IconButton>
                  </Tooltip>
                  <Tooltip title="Edit">
                    <IconButton onClick={() => onEditBook(book)}>
                      <RemoveCircleOutlineIcon />
                    </IconButton>
                  </Tooltip>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </TableContainer>
        <TablePagination
          rowsPerPageOptions={[10, 25, 100]}
          component="div"
          count={totalItems}
          rowsPerPage={rowsPerPage}
          page={page}
          onPageChange={onChangePage}
          onRowsPerPageChange={onChangeRowsPerPage}
        />
      </Table>
    </Paper>
  );
};

export default SearchResultsTable;
