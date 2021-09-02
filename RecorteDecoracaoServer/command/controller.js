import { ClearStdInInputEvent } from '../constants/regexp.js'

export default function (chunk, { command, text, server }) {
  const input = chunk.toString().replace(ClearStdInInputEvent, '')

  // is command
  if (/\-\-\w+/g.test(input)) {
    command({ text: input, server })
  } 
  
  // is not command
  else {
    text({ text: input, server })
  }
}