import { useState } from 'react';
import { Input } from '@/components/ui/input';

type SearchBarProps = {
  disabled: boolean
  onSearch: (text: string) => void
}

export default function SearchBar({ disabled, onSearch }: SearchBarProps) {
  const [text, setText] = useState('');

  const handleInput = (text: string) => {
    setText(text)
    onSearch(text)
  }

  return (
    <Input type="text" value={text} onChange={event => handleInput(event.target.value)} disabled={disabled} />
  )
}
