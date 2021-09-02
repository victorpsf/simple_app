import LogMiddleware from './log.js'

export default function (server) {
  server.use(LogMiddleware)
}