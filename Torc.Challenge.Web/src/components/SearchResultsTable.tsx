import React from 'react';
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
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

interface BookListData {
  booksData: Book[];
  setLoading: React.Dispatch<React.SetStateAction<boolean>>;
  onSearchBooks: () => Promise<void>;
}

const SearchResultsTable: React.FC<BookListData> = ({ booksData, setLoading, onSearchBooks }) => {
  const onIncreaseCopies = async (book: Book) => {
    setLoading(true);
    book.copiesInUse++;
    await api.put(`/api/books/${book.bookId}`, book);
    setLoading(false);
    await onSearchBooks();
  };

  const onDecreaseCopies = async (book: Book) => {
    setLoading(true);
    book.copiesInUse--;
    await api.put(`/api/books/${book.bookId}`, book);
    setLoading(false);
    await onSearchBooks();
  };

  return (
    <TableContainer component={Paper}>
      <Table aria-label="search results table">
        <TableHead>
          <TableRow>
            <TableCell style={{ fontWeight: 'bold' }}>Book Title</TableCell>
            <TableCell style={{ fontWeight: 'bold' }}>Authors</TableCell>
            <TableCell style={{ fontWeight: 'bold' }}>Type</TableCell>
            <TableCell style={{ fontWeight: 'bold' }}>ISBN</TableCell>
            <TableCell style={{ fontWeight: 'bold' }}>Category</TableCell>
            <TableCell style={{ fontWeight: 'bold' }}>Available Copies</TableCell>
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
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default SearchResultsTable;
