/// <reference types="vite/client" />

interface ImportMetaEnv {
  readonly PH_API_GATEWAY_URL: string
  readonly PH_IDENTITY_API_URL: string
}

interface ImportMeta {
  readonly env: ImportMetaEnv
}
