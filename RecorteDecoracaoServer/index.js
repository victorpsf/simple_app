import process from 'process'
import express from 'express'
import dotenv from 'dotenv'

import ControllerCommand from './command/controller.js'
import CommandListen from './command/command.js'
import TextListen from './command/text.js'

import api from './api/index.js'
import middleware from './middleware/index.js'

dotenv.config();
const server = express();

process.stdin.on(
  'data',
  (chunk) => ControllerCommand(chunk, { server, text: TextListen, command: CommandListen })
);

middleware(server);
api(server);

server.listen(3000);
