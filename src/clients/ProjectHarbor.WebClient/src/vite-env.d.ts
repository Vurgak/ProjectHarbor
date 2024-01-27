/// <reference types="vite/client" />

interface ImportMetaEnv {
  readonly PH_API_GATEWAY_URL: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}
